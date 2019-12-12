# Monetization FAQs
### Integration FAQs
#### [Which version of Unity should I be using?](MonetizationBasicIntegration.md)
#### [Why am I not able to see any ads in game?](https://support.unity3d.com/hc/en-us/articles/217262566-Why-don-t-I-see-ads-in-my-game-)
#### [Why am I only seeing 2 or 3 ads at a time?](MonetizationResourcesStatistics.md#fill-rate)
#### [What are some games that currently use Unity Ads?](MonetizationResourcesBestPracticesAds.md#case-studies-and-references)
#### [Can I use ad Placements to promote my other games?](MonetizationCrossPromotions.md)
#### [Is it possible to block certain types of ads from my game?](MonetizationResourcesDashboardGuide.md#ad-content-filters)
#### [Is it possible to block ads from certain developers?](MonetizationResourcesDashboardGuide.md#ad-content-filters)
#### [Can the daily number of available ads be limited?](MonetizationResourcesStatistics.md#fill-rate)
#### [Can Unity Ads be implemented through mediation?](MonetizationResourcesMediation.md)

### Stats FAQs
#### [What do the fields in the monetization stat reports mean?](MonetizationResourcesStatistics.md#understanding-unity-ads-metrics)
#### [Is it possible to automatically generate stat reports?](MonetizationResourcesStatistics.md#configuring-an-automated-report)
#### [How often are monetization stats updated?](MonetizationResourcesStatistics.md#understanding-unity-ads-metrics)

### Revenue FAQs
#### [Why am I not seeing any revenue, even with 100 impressions?](MonetizationResourcesRevenueAndPayment.md#analyzing-revenue)
#### [Is revenue earned by completed views, or based on installs?](MonetizationResourcesBestPracticesAds.md#understanding-how-ads-generate-revenue)
#### [How much money can I expect to make with my game?](MonetizationResourcesRevenueAndPayment.md#monetization-factors)

### Payment FAQs
#### [How does the payment process work?](MonetizationResourcesRevenueAndPayment.md#payment)
#### [Do I need to pay taxes on payments as an individual?](MonetizationResourcesRevenueAndPayment.md#requesting-payment-as-an-individual)
#### [Do I need to provide a VAT number?](MonetizationResourcesRevenueAndPayment.md#tax-information)
#### [When can I expect to be paid?](MonetizationResourcesRevenueAndPayment.md#minimum-payout-amount-and-fulfillment)
#### [My earnings balance was deducted by the amount invoiced, but I have yet to receive payment. What is the reason for this?](MonetizationResourcesRevenueAndPayment.md#minimum-payout-amount-and-fulfillment)

### IAP Promo FAQs
#### [Can I delete Placements in the dashboard?](https://support.unity3d.com/hc/en-us/articles/360000326546-Can-I-delete-Placements-in-the-dashboard-)
#### [How can I cap the frequency of Placements that get called often (e.g. return to lobby)?](https://support.unity3d.com/hc/en-us/articles/360000326526-How-can-I-cap-the-frequency-of-Placements-that-get-called-often-e-g-return-to-lobby-)
#### [How do I set up a limited-time offer?](https://support.unity3d.com/hc/en-us/articles/360000326466-How-do-I-set-up-a-limited-time-offer-)
#### [How are creatives uploaded for different devices and languages handled?](https://support.unity3d.com/hc/en-us/articles/360000326566-How-are-creatives-uploaded-for-different-devices-and-languages-handled-)
#### [Why am I seeing an error when trying to export my IAP Product Catalog to JSON in Unity 2017.3?](https://support.unity3d.com/hc/en-us/articles/360000326303-Why-am-I-seeing-an-error-when-trying-to-export-my-IAP-Product-Catalog-to-JSON-in-Unity-2017-3-)
#### [Why doesn’t the creative I uploaded exactly match what I see on my device?](https://support.unity3d.com/hc/en-us/articles/360000326586-Why-doesn-t-the-creative-I-uploaded-exactly-match-what-I-see-on-my-device-)
#### [Why isn't my Placement showing any Promotions?](https://support.unity3d.com/hc/en-us/articles/360000326446-Why-isn-t-my-Placement-showing-any-Promotions-)

### Personalized Placements FAQs
#### Do Personalized Placements work with mediation?
Yes. To use with mediation, you must integrate your Personalized Placements with your mediation partner’s Unity adapter as you would a normal [Placement](MonetizationPlacements.md). The actual integration will differ by partner. For more information, see documentation on [mediation](MonetizationResourcesMediation.md). 
#### What ad formats do Personalized Placements support?
Personalized Placements support interstitial or rewarded video, playable, and display ads (for more information, see documentation on [Monetization content types](MonetizationContentTypes.md)). 
 
* [Integration guide](MonetizationBasicIntegrationUnity.md) for Unity developers (C#)
* [Integration guide](MonetizationBasicIntegrationIos.md) for iOS developers (Objective-C)
* [Integration guide](MonetizationBasicIntegrationAndroid.md) for Android developers (Java)  

#### How is the control group for my observation phase (phase one) implementation formed?
In the beta, there is an [observation phase](MonetizationPersonalizedPlacementsScale.md#what-to-expect-in-the-observation-phase) to prove revenue lift by randomly selecting 50% of the player base to experience optimized content, while the other 50% act as a control group. If you have questions about the random selection process, or how users are redistributed for the [scaling phase](MonetizationPersonalizedPlacementsScale.md#what-to-expect-in-the-scaling-phase) (phase two) expanded exposure, please contact your Unity representative. 
#### When will I see revenue lift from Personalized Placements?
You should see immediate lift, however the machine learning engine usually takes about two weeks to optimize, depending on how many daily active users play your game. This can vary, depending on where you choose to implement your Placements (for example, at the beginning of the game versus the end of the game), which is why Unity recommends multiple Personalized Placements spread throughout the game to deliver a consistent experience. As with any machine learning model, expect performance to improve over time.  
#### How does Unity determine the optimal content to display?
Personalized Placements optimize toward lifetime value (LTV) for retention and sustainable revenue. Unity calculates the LTV of a player by projecting their total potential value over an infinite amount of time. This model considers many factors beyond bid value. For more information, see documentation on [how Personalized Placements work](MonetizationPersonalizedPlacements.md).