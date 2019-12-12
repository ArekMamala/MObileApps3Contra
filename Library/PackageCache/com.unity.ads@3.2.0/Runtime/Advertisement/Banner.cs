#if UNITY_EDITOR
using System;
#elif UNITY_ANDROID
using System;
using System.Collections.Generic;
#elif UNITY_IOS
using System;
using System.Runtime.InteropServices;
using AOT;
#endif

namespace UnityEngine.Advertisements
{
    #if UNITY_EDITOR
    [AddComponentMenu("")]
    sealed internal class Banner : MonoBehaviour, IBanner
    {
        public event EventHandler<StartEventArgs> OnShow;
        public event EventHandler<HideEventArgs> OnHide;
        public event EventHandler<ErrorEventArgs> OnError {
            add { }
            remove { }
        }
        public event EventHandler<EventArgs> OnUnload;
        public event EventHandler<EventArgs> OnLoad;

        private bool m_showing;
        private string m_placementId;
        private bool loaded { get; set; }
        public Texture2D aTexture;

        private BannerPosition bannerPosition = BannerPosition.BOTTOM_CENTER;

        public void Awake()
        {
            m_showing = false;
            aTexture = backgroundTexture(320, 50, Color.grey);
        }

        public bool isLoaded => loaded;

        /// <summary>
        /// Loads the banner ad with a specified <a href="../manual/MonetizationPlacements.html">Placement</a>, and no callbacks.
        /// </summary>
        /// <param name="placementId">The unique identifier for a specific Placement, found on the <a href="https://operate.dashboard.unity3d.com/">developer dashboard</a>.</param>
        public void Load(string placementId)
        {
            loaded = true;
            OnLoad?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Allows you to hide a banner ad, instead of destroying it altogether.
        /// </summary>
        public void Hide(bool destroy = false)
        {
            this.m_showing = false;
            loaded = false;
            OnHide?.Invoke(this, new HideEventArgs(m_placementId));
            OnUnload?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Displays the banner ad with a specified <a href="../manual/MonetizationPlacements.html">Placement</a>, and no callbacks.
        /// </summary>
        /// <param name="placementId">The unique identifier for a specific Placement, found on the <a href="https://operate.dashboard.unity3d.com/">developer dashboard</a>.</param>
        public void Show(string placementId)
        {
            loaded = true;
            m_placementId = placementId;
            m_showing = true;
            OnShow?.Invoke(this, new StartEventArgs(placementId));
        }

        /// <summary>
        /// <para>Sets the position of the banner ad, using the <a href="../api/UnityEngine.Advertisements.BannerPosition.html"><c>BannerPosition</c></a> enum.</para>
        /// <para>Banner position defaults to <c>BannerPosition.BOTTOM_CENTER</c>.</para>
        /// </summary>
        /// <param name="position">An enum representing the on-screen anchor position of the banner ad.</param>
        public void SetPosition(BannerPosition position)
        {
            bannerPosition = position;
        }

        void OnGUI()
        {
            if (!this.m_showing)
            {
                return;
            }
            GUIStyle myStyle = new GUIStyle(GUI.skin.box);
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = 20;
    
            if(aTexture){
                GUI.DrawTexture(getBannerRect(bannerPosition), aTexture, ScaleMode.ScaleToFit);
                GUI.Box(getBannerRect(bannerPosition), "This would be your banner", myStyle);
            }
        }

        void OnApplicationQuit()
        {
            m_showing = false;
        }

        private Texture2D backgroundTexture(int width, int height, Color color)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; i++)
            {
                pix[i] = color;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }

        private Rect getBannerRect(BannerPosition position)
        {
            switch(position)
            {
                case BannerPosition.TOP_CENTER:
                    return (new Rect(Screen.width / 2 - 160, 0, 320, 50));
                case BannerPosition.TOP_LEFT:
                    return (new Rect(0, 0, 320, 50));
                case BannerPosition.TOP_RIGHT:
                    return (new Rect(Screen.width - 320, 0, 320, 50));
                case BannerPosition.CENTER:
                    return (new Rect(Screen.width / 2 -160, Screen.height / 2 - 25, 320, 50));
                case BannerPosition.BOTTOM_CENTER:
                    return (new Rect(Screen.width / 2 -160, Screen.height - 50, 320, 50));
                case BannerPosition.BOTTOM_LEFT:
                    return (new Rect(0, Screen.height - 50, 320, 50));
                case BannerPosition.BOTTOM_RIGHT:    
                    return (new Rect(Screen.width - 320, Screen.height - 50, 320, 50));
                default:
                    return (new Rect(Screen.width / 2 - 160, Screen.height - 50, 320, 50));
            }
        }
    }
    #elif UNITY_ANDROID
    static class Color
    {
        public const int Transparent = 0;
    }

    sealed internal class Banner : AndroidJavaProxy, IBanner
    {
        private AndroidJavaClass m_BannersClass;
        private AndroidJavaObject m_CurrentActivity;
        private CallbackExecutor m_CallbackExecutor;

        private AndroidJavaObject m_BannerView;
        private AndroidJavaObject m_PopUp;
        private bool m_showAfterLoad;

        public event EventHandler<StartEventArgs> OnShow;
        public event EventHandler<HideEventArgs> OnHide;
        public event EventHandler<ErrorEventArgs> OnError;
        public event EventHandler<EventArgs> OnUnload;
        public event EventHandler<EventArgs> OnLoad;

        public Banner(AndroidJavaObject currentActivity, CallbackExecutor callbackExecutor) : base("com.unity3d.services.banners.IUnityBannerListener")
        {
            m_BannersClass = new AndroidJavaClass("com.unity3d.services.banners.UnityBanners");
            m_CurrentActivity = currentActivity;
            m_CallbackExecutor = callbackExecutor;

            m_BannersClass.CallStatic("setBannerListener", this);
        }

        public bool isLoaded => m_BannerView != null;

        public void Load(string placementId)
        {
            if (m_BannerView != null)
            {
                var handler = OnLoad;
                if (handler != null)
                {
                    m_CallbackExecutor.Post((executor) =>
                    {
                        handler(this, EventArgs.Empty);
                    });
                }
            }
            else
            {
                if (placementId != null)
                {
                    m_BannersClass.CallStatic("loadBanner", m_CurrentActivity, placementId);
                }
                else
                {
                    m_BannersClass.CallStatic("loadBanner", m_CurrentActivity);
                }
            }
        }

        public void Hide(bool destroy = false)
        {
            if (m_BannerView != null)
            {
                if (destroy)
                {
                    m_BannerView = null;
                    m_BannersClass.CallStatic("destroy");
                }
                else
                {
                    m_CurrentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                        var parent = m_BannerView.Call<AndroidJavaObject>("getParent");
                        if (parent != null)
                        {
                            parent.Call("removeView", m_BannerView);
                        }
                    }));
                }
            }
        }

        public void Show(string placementId)
        {
            if (m_BannerView != null)
            {
                m_CurrentActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    var parent = m_BannerView.Call<AndroidJavaObject>("getParent");
                    if (parent == null)
                    {
                        m_CurrentActivity.Call("addContentView", m_BannerView, new AndroidJavaObject("android.widget.LinearLayout$LayoutParams", -1, -1));
                    }
                }));
            }
            else
            {
                m_showAfterLoad = true;
                Load(placementId);
            }
        }

        public void SetPosition(BannerPosition position)
        {
                var index = (int)position;
                var enumClass = new AndroidJavaClass("com.unity3d.services.banners.view.BannerPosition");
                var values = enumClass.CallStatic<AndroidJavaObject>("values");
                var bannerPosition = new AndroidJavaClass("java.lang.reflect.Array").CallStatic<AndroidJavaObject>("get", values, index);

                m_BannersClass.CallStatic("setBannerPosition", bannerPosition);
        }

        void onUnityBannerShow(string placementId)
        {
            var handler = OnShow;
            if (handler != null)
            {
                m_CallbackExecutor.Post((executor) =>
                {
                    handler(this, new StartEventArgs(placementId));
                });
            }
        }

        void onUnityBannerHide(string placementId)
        {
            var handler = OnHide;
            if (handler != null)
            {
                m_CallbackExecutor.Post((executor) =>
                {
                    handler(this, new HideEventArgs(placementId));
                });
            }
        }

        void onUnityBannerLoaded(String placementId, AndroidJavaObject view)
        {
            m_BannerView = view;
            m_BannerView.Call("setBackgroundColor", Color.Transparent);
            if (m_showAfterLoad)
            {
                m_showAfterLoad = false;
                m_CurrentActivity.Call("addContentView", m_BannerView, new AndroidJavaObject("android.widget.LinearLayout$LayoutParams", -1, -1));
            }
            var handler = OnLoad;
            if (handler != null)
            {
                m_CallbackExecutor.Post((executor) =>
                {
                    handler(this, EventArgs.Empty);
                });
            }
        }

        void onUnityBannerUnloaded(String placementId)
        {
            var handler = OnUnload;
            if (handler != null)
            {
                m_CallbackExecutor.Post((executor) =>
                {
                    handler(this, EventArgs.Empty);
                });
            }
        }

        void onUnityBannerClick(string placementId)
        {
            // Not implemented.
        }

        void onUnityBannerError(string message)
        {
            var handler = OnError;
            if (handler != null)
            {
                m_CallbackExecutor.Post((executor) =>
                {
                    handler(this, new ErrorEventArgs(message));
                });
            }
        }
    }
    #elif UNITY_IOS
    sealed internal class Banner : IBanner
    {
        static Banner s_Instance;
        static CallbackExecutor s_CallbackExecutor;

        public event EventHandler<StartEventArgs> OnShow;
        public event EventHandler<HideEventArgs> OnHide;
        public event EventHandler<ErrorEventArgs> OnError;
        public event EventHandler<EventArgs> OnUnload;
        public event EventHandler<EventArgs> OnLoad;

        delegate void unityAdsBannerShow(string placementId);
        delegate void unityAdsBannerHide(string placementId);
        delegate void unityAdsBannerClick(string placementId);
        delegate void unityAdsBannerUnload(string placementId);
        delegate void unityAdsBannerLoad(string placementId);
        delegate void unityAdsBannerError(string message);

        [DllImport("__Internal")]
        static extern void UnityAdsBannerShow(string placementId, bool showAfterLoad);
        [DllImport("__Internal")]
        static extern void UnityAdsBannerHide(bool shouldDestroy);
        [DllImport("__Internal")]
        static extern bool UnityAdsBannerIsLoaded();
        [DllImport("__Internal")]
        static extern void UnityAdsBannerSetPosition(int position);

        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerShowCallback(unityAdsBannerShow callback);
        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerHideCallback(unityAdsBannerHide callback);
        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerClickCallback(unityAdsBannerClick callback);
        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerErrorCallback(unityAdsBannerError callback);
        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerUnloadCallback(unityAdsBannerUnload callback);
        [DllImport("__Internal")]
        static extern void UnityAdsSetBannerLoadCallback(unityAdsBannerLoad callback);
        [DllImport("__Internal")]
        static extern void UnityBannerInitialize();

        public Banner(CallbackExecutor callbackExecutor)
        {
            s_CallbackExecutor = callbackExecutor;
            s_Instance = this;

            UnityAdsSetBannerShowCallback(UnityAdsBannerDidShow);
            UnityAdsSetBannerHideCallback(UnityAdsBannerDidHide);
            UnityAdsSetBannerClickCallback(UnityAdsBannerClick);
            UnityAdsSetBannerErrorCallback(UnityAdsBannerDidError);
            UnityAdsSetBannerUnloadCallback(UnityAdsBannerDidUnload);
            UnityAdsSetBannerLoadCallback(UnityAdsBannerDidLoad);
            UnityBannerInitialize();
        }

        public bool isLoaded => UnityAdsBannerIsLoaded();

        public void Load(string placementId)
        {
            UnityAdsBannerShow(placementId, false);
        }

        public void Show(string placementId)
        {
            UnityAdsBannerShow(placementId, true);
        }

        public void Hide(bool destroy = false)
        {
            UnityAdsBannerHide(destroy);
        }

        public void SetPosition(BannerPosition position){
            UnityAdsBannerSetPosition((int)position);
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerShow))]
        static void UnityAdsBannerDidShow(string placementId)
        {
            var handler = s_Instance.OnShow;
            if (handler != null)
            {
                s_CallbackExecutor.Post((executor) =>
                {
                    handler(s_Instance, new StartEventArgs(placementId));
                });
            }
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerHide))]
        static void UnityAdsBannerDidHide(string placementId)
        {
            var handler = s_Instance.OnHide;
            if (handler != null)
            {
                s_CallbackExecutor.Post((executor) =>
                {
                    handler(s_Instance, new HideEventArgs(placementId));
                });
            }
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerClick))]
        static void UnityAdsBannerClick(string placementId)
        {
            // Not implemented.
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerError))]
        static void UnityAdsBannerDidError(string message)
        {
            var handler = s_Instance.OnError;
            if (handler != null)
            {
                s_CallbackExecutor.Post((executor) =>
                {
                    handler(s_Instance, new ErrorEventArgs(message));
                });
            }
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerUnload))]
        static void UnityAdsBannerDidUnload(string placementId)
        {
            var handler = s_Instance.OnUnload;
            if (handler != null)
            {
                s_CallbackExecutor.Post((executor) =>
                {
                    handler(s_Instance, EventArgs.Empty);
                });
            }
        }

        [MonoPInvokeCallback(typeof(unityAdsBannerUnload))]
        static void UnityAdsBannerDidLoad(string placementId)
        {
            var handler = s_Instance.OnLoad;
            if (handler != null)
            {
                s_CallbackExecutor.Post((executor) =>
                {
                    handler(s_Instance, EventArgs.Empty);
                });
            }
        }
    }
    #endif
}