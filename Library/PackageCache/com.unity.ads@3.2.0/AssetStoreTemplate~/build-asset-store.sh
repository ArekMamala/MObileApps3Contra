#!/bin/bash

set -e

rsync --exclude '*.bak' -rv AssetStoreTemplate~/asset-store-template/ build
rsync --exclude '*.bak' -rv Plugins/ build/Assets/Plugins/
rsync --exclude '*.bak' -rv Editor/Resources/ build/Assets/Editor/Resources/

file_name=.Editor/Unity.app/Contents/Managed/UnityEngine.dll

if [ -f $file_name ]; then
	echo "$file_name exists"	
else   
 	echo "$file_name does not exists"
 	file_name=/Applications/Unity/Unity.app/Contents/Managed/UnityEngine.dll
fi

mcs -out:build/Assets/UnityAds/UnityEngine.Advertisements.Android.dll -r:$file_name -sdk:2 -d:"ASSET_STORE;UNITY_ANDROID;UNITY_ADS" -recurse:Runtime/Advertisement/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Advertisements.iOS.dll -r:$file_name -sdk:2 -d:"ASSET_STORE;UNITY_IOS;UNITY_ADS" -recurse:Runtime/Advertisement/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Advertisements.Editor.dll -r:$file_name -sdk:2 -d:"ASSET_STORE;UNITY_EDITOR;UNITY_ADS" -recurse:Runtime/Advertisement/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Advertisements.Unsupported.dll -r:$file_name -sdk:2 -d:"ASSET_STORE;UNITY_ADS" -recurse:Runtime/Advertisement/*.cs -target:library

mcs -out:build/Assets/UnityAds/UnityEngine.Monetization.Android.dll -r:$file_name,build/Assets/UnityAds/UnityEngine.Advertisements.Android.dll -sdk:2 -d:"ASSET_STORE;UNITY_ANDROID;UNITY_ADS" -recurse:Runtime/Monetization/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Monetization.iOS.dll -r:$file_name,build/Assets/UnityAds/UnityEngine.Advertisements.iOS.dll -sdk:2 -d:"ASSET_STORE;UNITY_IOS;UNITY_ADS" -recurse:Runtime/Monetization/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Monetization.Editor.dll -r:$file_name,build/Assets/UnityAds/UnityEngine.Advertisements.Editor.dll -sdk:2 -d:"ASSET_STORE;UNITY_EDITOR;UNITY_ADS" -recurse:Runtime/Monetization/*.cs -target:library
mcs -out:build/Assets/UnityAds/UnityEngine.Monetization.Unsupported.dll -r:$file_name,build/Assets/UnityAds/UnityEngine.Advertisements.Unsupported.dll -sdk:2 -d:"ASSET_STORE;UNITY_ADS" -recurse:Runtime/Monetization/*.cs -target:library

rm -rf temp
mkdir temp

for metaFile in `find build -name '*.meta'`; do
	guid=`grep guid $metaFile | grep -o "[a-z0-9]*$"`
	file=`echo $metaFile | sed s/.meta//`
	path=`echo $file | sed "s/build\///"`
	mkdir temp/$guid
	if [ ! -d $file ]; then
		cp $file temp/$guid/asset
	fi
	cp $metaFile temp/$guid/asset.meta
	echo $path > temp/$guid/pathname
done

tar czf build/UnityAds.unitypackage -C temp .
rm -rf temp