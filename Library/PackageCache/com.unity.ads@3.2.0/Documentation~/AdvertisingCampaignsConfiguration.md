# Configuring campaigns
## Overview
This article provides a comprehensive look at each setting for your campaigns. Access campaigns through the [Acquire dashboard](https://acquire.dashboard.unity3d.com).

### Guide contents
* [Creative packs](#creative-packs) 
* [Bids](#bids)
* [Budgets](#budgets)
* [Scheduling](#scheduling)
* [User targeting](#targeting)
* [Attribution tracking links](#tracking-links)

## Creative packs
Creative packs are the content of your ad campaign. You can now assign more than one creative pack to a single campaign. This means you don’t need to create multiple campaigns in order to run additional creative packs for a single ad campaign. Furthermore, multiple campaigns can share the same creative packs, so long as they’re for the same app. 

**Note:** When a campaign contains multiple creative packs, an algorithm determines the optimal one to show for each user. 

### Adding a new creative pack
In the **Creative packs** section of the campaign page, click **CREATE** (or **CREATE CREATIVE PACKS** if none exist yet).

![Setting up a new creative pack.](images/NewCreatives.png)

Enter a **creative pack name**, then upload **end card** and **video** assets (detailed below).

#### End cards
End cards are creative assets displayed at the end of an ad with a call to action for users to download the advertised product. 

Select **Square** end cards from the dropdown menu to upload one creative format that will work on any device, in any orientation, and any aspect ratio (recommended to prevent cropping and maximize compatibility).

Select **Portrait & landscape** end cards from the dropdown menu to upload one creative for each device orientation.

The following specs apply to end cards:
 
* Use JPG or PNG format.
* Use one of the following dimension formats: 
  * For square end cards, use 800 x 800 (1:1) pixel resolution.
  * Otherwise, use 800 x 600 (4:3) pixel resolution for landscape images and 600 x 800 (3:4) pixel resolution for portrait images.
* (Apple only) Due to Apple requirements, Unity recommends only depicting the Apple app store logo on end cards for iOS videos. See [Apple marketing guidelines](https://developer.apple.com/app-store/marketing/guidelines/#badges) for more information.

**Note**: Dynamic cropping may occur when using landscape and portrait images, to account for different device sizes. To avoid losing critical information, allow a 100-pixel buffer from the top and bottom edges of landscape images, or left and right edges for portrait images.

#### Videos
Video ad assets marketing your app. While only one video is required, uploading a video for each orientation yields better optimization. When a creative contains both, Unity’s valuation algorithm selects the best orientation to display.

* 30 seconds or less.
* H.264-encoded MP4 format.
* 16:9 pixel ratio for landscape videos, or 9:16 pixel ratio for portrait videos.
* Recommended file size is 10MB. Maximum file size is 100MB. Videos are re-encoded to be suitable for various bitrates. The final video shown will be optimized for the user's available network speed and cache settings.
* (Apple only) Due to Apple requirements, Unity recommends only depicting the Apple app store logo. See [Apple marketing guidelines](https://developer.apple.com/app-store/marketing/guidelines/#badges) for more information.

![Uploading creative assets for your campaign.](images/UploadCreatives.png)
 
When finished uploading creative assets, click **CREATE**. Your new creative pack now appears in the campaign’s **Creative Packs** list with a **Processing** status. This status indicates that your creative pack is undergoing moderation (see section on **Moderation** below). Click **ASSIGN** to choose which creative packs to include with the campaign. Note that selecting the downward arrow expands the creative pack’s details.

### Moderation
All new creative packs undergo a moderation process to ensure they adhere to Unity's [advertising content policies](https://unity3d.com/legal/advertising-content-policy) before running in a live campaign. The review automatically triggers when a new creative pack’s associated campaign goes live for the first time. No further action is required of you.

**Note:** Campaigns must contain at least one approved creative pack to go live. If your live campaign includes a mix of approved and pending creative packs, the pending ones will automatically run once approved. 

**Important**: Due to the sensitive nature of gambling ads across many of our publishers, Unity requires gambling advertisers to be managed accounts. Gambling creatives from unmanaged partners will be rejected in moderation. To become a managed partner or learn more about Unity's gambling ad policies, please [contact us](mailto:adops-support@unity3d.com). 

## Bids
Unity Ads is a bidding platform. The exposure of your ad campaign depends on its eCPM (effective cost per thousand impressions), which is determined by the CVR (video conversion rate from impression to install) and CPI (cost per install) of your campaign. The higher your campaign’s eCPM, the more exposure it receives. 

### Adding new bids
To add a bid, scroll to the **Bids** section and click **ADD**.

![Adding a bid to your campaign.](images/NewBid.png)

Use the **Search** tool to locate a country, or expand a region from the dropdown list to specify desired bids in each of that region’s countries. Selecting a region adds the default values for every country in that region (you can adjust or exclude these selections later if needed). 

**Note:** Unity provides default values as a baseline, using average bid values for each region. You will likely want to modify them to fit your individual needs, app type, and marketing strategy.

![Specifying bid values by region and country.](images/CountryBidSelect.png)

### Editing bids
To edit an existing bid, click **EDIT**, then select the bid(s) to edit. 

![Editing a bid.](images/EditBid.png)

Hover over a bid value to display an edit icon (see image below). Select the edit icon to manually enter a new bid value.

![Manually editing a bid value.](images/SelectBid.png)

Make bulk edits by selecting the countries or regions to adjust, then selecting the **Increase By Percentage** dropdown to select from the following operations:

* **Increase By Percentage**: increases all selected bids by the specified % (for example, if the value is 25%, a $4.00 bid becomes a $5.00 bid). 
* **Decrease By Percentage**: decreases all selected bids by the specified % (for example, if the value is 25%, a $4.00 bid becomes a $3.00 bid).
* **Increase By Value**: increases all selected bids by the specified dollar value (for example, if the value is 1, a $4.00 bid becomes a $5.00 bid).
* **Decrease By Value**: decreases all selected bids by the specified dollar value (for example, if the value is 1, a $4.00 bid becomes a $3.00 bid).
* **Change To Value**: sets all selected bids to the specified dollar value (for example, if the value is 1, a $4.00 bid becomes a $1.00 bid).

Enter the new value, then click **APPLY** to process the operation to all selected bids.

![Bulk-editing bids by percentage.](images/BulkBidEdit.png)

Click **SAVE** to apply changes.

### Deleting bids
To delete an existing bid, click **DELETE**, then select the bid(s) to delete. Select bids using the **Search** tool, by country, or in bulk by region. 

![Deleting a bid.](images/DeleteBid.png)

Affected bids display strikethrough font. Click **DELETE** to confirm their removal.

![Specifying bids to delete.](images/DeleteBidSelect.png)

## Campaign details
Edit the campaign **Name** and **Bid type**. Currently the only supported bid type is **CPI** (cost per install). 

## Budgets
Your campaign budget dictates how much marketing spend the campaign could consume. The default value is **unlimited**. To specify a budget limit, select the edit icon, then check **Limit campaign budget**. You can either select an existing budget or create a new one.

### Creating a new budget
Select the **Choose budget** dropdown, then select **ADD BUDGET**.

![Creating a new budget.](images/NewBudget.png)

Next, enter the **Budget name** and total **Budget Limit**. If you want to limit the amount per day, check **Limit daily budget** and enter the desired amount. 

### Editing Budgets
Select the edit icon, then select the budget to edit from the **Choose budget** dropdown. Click **EDIT BUDGET** to display the budget editing interface.

![Editing an existing budget.](images/EditBudgetDetails.png)

Choose whether to **Increase budget by** or **Decrease budget by** the dollar value entered. The resulting remaining budget appears when you enter a value. Click **SAVE BUDGET** to apply your changes.

**Note:** Since multiple campaigns can draw from the same budget, remember that your changes may impact other campaigns.

## Scheduling
Specify the start and end date parameters for your campaign to run. All dates begin at midnight UTC.

### Runs from 
Defines the start date of the campaign. The default value is the current date. Select the edit icon to specify a different date.

**Note:** Regardless of this date, a campaign must be set to live and meet the necessary criteria in order to run. 

### Runs until 
Defines the end date of the campaign. The default value is Not set (the campaign will run indefinitely, or until out of budget or paused). Select the edit icon to specify a different date.

![Scheduling the run period for a campaign.](images/Scheduling.png)

## Targeting
Use this section to refine your targeted devices. You only bid for users that fit specified criteria.

### Internet Connection
Select the edit icon, then check all desired options (**wifi** or **cellular**). We recommend selecting both to broaden the reach of your campaign. Click **SAVE** to apply your preferences. 

### Operating System
Select the edit icon, then select a **Minimum OS version** and a **Maximum OS version** from the dropdowns to define the OS range (note that the platform associated with your app’s store URL determines the list of operating systems). Click **SAVE** to apply your preferences.

![Selecting operating system parameters for audience targeting.](images/OSTargeting.png)

### Device (Apple only)
Select the edit icon, then check all desired iOS devices. Click **SAVE** to apply your preferences.

### Screen Size (Google only)
Select the edit icon, then check all desired options:

* **small** (at least 426 x 320 pixels)
* **normal** (at least 470 x 320 pixels)
* **large** (at least 640 x 480 pixels)
* **xlarge** (at least 960 x 720 pixels)

Click **SAVE** to apply your preferences.

### Screen Density (Google only)
Select the edit icon, then check all desired options:

* **Ldpi** (120dpi)
* **mdpi** (160dpi)
* **hdpi** (240dpi)
* **xhdpi** (320dpi)
* **xxhdpi** (480dpi)
* **xxxhdpi** (640dpi)
 
Click **SAVE** to apply your preferences.

## Tracking Links
Specify URLs with which to track impression engagement. These URLs help gauge campaign performance by tracking when users interact with your ad video through this campaign:

### Start 
The attribution event executes before a video begins.

### View 
The attribution event executes when the video ends.

### Click 
The attribution event executes when a user clicks the download button.

**Note**: Campaigns require a **Click** attribution link. However, we recommend assigning **Start** or **View** impression attribution links as well, in order to support higher conversion rate.

For more information on attribution links, see documentation on [server-to-server install tracking](AdvertisingCampaignsInstallTracking.md).

## What's next?
Learn how [Audience Pinpointer](AdvertisingOptimizationAudiencePinpointer.md) uses machine learning to dynamically bid on high value users.