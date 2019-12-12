# Advertising stats API (legacy)
**Important**: This article details how to use the deprecated Statistics API, and is not currently maintained. Please refer to the documentation on the new [Statistics API](AdvertisingResourcesStats.md).

Unity Ads provides an API for Publishers and Advertisers to retrieve monetization and acquisition statistics data directly in CSV format. The Unity Ads Statistics API can used to retrieve the game and campaign data for loading them up to partners own reporting system periodically. In practice, the statistics API is a machine-to-machine interface for fetching the same statistics files that have been available in the [Unity Ads Admin Panel][1] automatically.

### Overview
The statistics API works in two stages: First, the user performs an GET request to an authentication server which, after a successful authentication, responds with a 302 HTTP redirect message. This response contains a the final URL to the statistics server.

Next, when the user performs an GET request to the signed URL, the located server will respond with the requested data in CSV format in the body of the message:

```
Date,Target campaign id,Target name,clicks
2013-02-28 00:00:00,"5065e1f1fdeb285e4d0430ce","Campaign 1",129
2013-02-28 00:00:00,"50ed569d57fe1e324415fbf7","Campaign 2",428
2013-02-28 00:00:00,"50eeb7c39610c9d21c0225cb","Campaign 3",812
2013-02-28 00:00:00,"511e5f7a73452a3363062d5d","Campaign 4",130
...
```

### Authentication
In order to use the Unity Ads Statistics API, you need to get the API key from the [Unity Ads Admin Panel][1]. The API key is located in the [Account Settings][2] page.

The API key needs to be placed in the authentication request to the `apikey` HTTP GET parameter.

After a successfull authentication the server will respond with a 302 HTTP-redirect message with the data URL to the statistics server located in the `Location` HTTP-header. The real data is fetched from this given redirect URL. This is a standard HTTP behavior and is supported by all HTTP clients. For example `curl -L "https://gameads-admin.applifier.com/stats/acquisition-api?apikey=APIKEY"` will directly output the file to the console.

The statistics server always requires signed URLs and will not work if accessed without a valid signature. If the authentication fails, the authentication server will respond with an HTTP/1.1 200 OK header with an error message in the body:

```
{"error":"Authentication error","responseCode":500,"status":"error"}
```

---

### Request Format

### Monetization statistics (Use this API to get statistics from your monetising games)

See separate document about monetisation stats API here:  [Unity Ads statistics API for monetisation](../Documentation for Publishers/Statistics-API-for-monetization)



### Acquisition statistics (Use this API to get statistics from your advertising campaigns)
The acquisition statistics API is similar to the monetization one and supports the following request format:

```
https://gameads-admin.applifier.com/stats/acquisition-api?apikey=<apikey>&fields=<fields>[&splitBy=<splitbyfields>][&scale=<scale>][&start=<startDate>][&end=<endDate>]([&targetIds=<targetIds>]|[&campaigns=<campaignIds>]
```
where:

- `<apikey>`: the api authentication key retrieved from the [Unity Ads Admin Panel][1]
- `<fields>`: a comma separated list of available fields:
    - `started`: number of impressions recorded
    - `views`: number of completed views recorded
    - `clicks`: number of clicks recorded
    - `installs`: number of installs recorded
    - `spend`: how much money was spent

The default set of fields is all of the above: "`clicks`,`installs`,`spend`".

- `<splitbyfields>` contains a comma-separated list of dimension in which to split the data:
    - `target` – the data is split by target games
    - `campaign` – the data is split by campaigns
    - `country` – the data is split by users’ country

The default split by is `country`. If you don’t want to split the data at all you can write `splitBy=none`. Either target or campaign split is allowed at the same time. Both can be used with or without country split.

> Note: Splitting the statistics data across multiple dimensions at the same time grows the data size exponentially. The processing time might end up being too long and cause the request to fail. All the requests taking more than a minute to generate the data will be terminated at 60 seconds.

- `<scale>` – contains the time resolution of the data. Each day is split at `00:00 UTC`. The available values for scale are:
 - `all` – removes time resolution completely and provides the total sum of values within the defined period
 - `hour`
 - `day`
 - `week`
 - `month`
 - `quarter`
 - `year`

The default is `day`.

- `<startDate>` & `<endDate>` – contains the start (inclusive) and end (exclusive) times for the data. The dates are accepted in following formats:
 - negative numbers are treated as days relative to the current date. For example: `-7` is a week ago.
 - Date string in ISO format `YYYY-MM-DDTHH:mm:SS:hhhZ`, for example: `2013-02-01T14:00:00.000Z`

The default start date is `-7` and end date is `0` to get the past week’s data.

> Note: The start and end dates will be rounded upwards to next full hour. For example, the `14:00:05.000Z` will be rounded to `15:00:00.000Z`. Also note that if using scale `day`, using non-midnight `<startDate>` & `<endDate>` will still select the range per hour and not the whole day.

- `<targetIds>` – comma separated list of target game ids to filter the results. By default, all the games of the advertiser will be included.
- `<campaigns>` – comma separated list of campaign ids to filter the results. By default, all the campaigns of the advertiser will be included.
> Note: The results can be filtered by either target games or campaigns, but not both at the same time.

Example:
```
curl -L "https://gameads-admin.applifier.com/stats/acquisition-api?apikey=c4ca4238a0b923820dcc509a6f75849bc81e728d9d4c2f636f067f89cc14862c&splitBy=campaign,country&fields=views,clicks&start=-31&scale=all&targetIds=8234,7432"
```

### Response Format
#### CSV format in general
The statistics server will output the requested statistics data in the HTTP response body. The data is in CSV format. Comma ‘,’ is used as the field separator and dot ‘.’ as the decimal separator. Text fields will have double quotes (‘”‘) around them. Pure integer fields don’t have double quotes, but decimal numbers (such as revenue and spend) are doublequoted. The unix newline character (`0x0D`) is used as the line separator. The first line of the output will contain the field names.

#### Fields
The leftmost field is always the `Date`. The date is in ISO format `YYYY-MM-DD HH:mm:SS`.

The next fields are the split dimensions (if selected) in the following order:

- For `target` splitted data, two fields `"Target game id"` and `"Target name"` will be shown.
- For `campaign` splitted data, two fields `"Target campaign id"` and `"Target name"` will be shown.
- For `country` splitted data, two fields `"Country code"` and `"Country tier"` will be shown. Country code is the `ISO 3166-1` alpha-2 country codes in upper case based the users’ GeoIP data. `"--"` is shown for those user IPs whose GeoIP location was unknown. - - The country tier is an integer denoting country’s classification in Applifier’s tier structure.

The rightmost fields are the data fields requested in the same order as in the request.

For example:
```
$ curl -L "https://gameads-admin.applifier.com/stats/acquisition-api?apikey=c4ca4238a0b923820dcc509a6f75849bc81e728d9d4c2f636f067f89cc14862c&splitBy=country,campaign"
Date,Target campaign id,Target name,Country code,Country tier,clicks,installs,spend
2013-03-01 00:00:00,"50ed569d57fe1f324a15fbf7","Campaign #5","AU",2,71,30,"45.00"
2013-03-01 00:00:00,"50ed569d57fe1f324a15fbf7","Campaign #5","CA",2,129,88,"132.00"
2013-03-01 00:00:00,"50ed569d57fe1f324a15fbf7","Campaign #5","US",1,1745,855,1282.50
2013-03-01 00:00:00,"50eeb7339e10c9d21c0225cb","Campaign #6","AT",3,39,19,"28.50"
2013-03-01 00:00:00,"50eeb7339e10c9d21c0225cb","Campaign #6","AU",2,16,10,"15.00"
2013-03-01 00:00:00,"50eeb7339e10c9d21c0225cb","Campaign #6","BE",3,209,120,"180.00"
2013-03-01 00:00:00,"50eeb7339e10c9d21c0225cb","Campaign #6","CA",2,284,179,"268.50"
2013-03-01 00:00:00,"50eeb7339e10c9d21c0225cb","Campaign #6","CH",3,15,7,"10.50"
...

```

[1]: https://unityads.unity3d.com/admin
[2]: https://unityads.unity3d.com/admin/#/account/settings
