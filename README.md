#Twitzer

###Introduction

All the servers of Twitter have been destroyed in an accident! All users have lost their precious tweets.
To fill the void, another company has decided to use this opportunity to launch their competitor, Twitzer.
Time is of essence and they need to get an app to market very quickly, before Twitter can relaunch their service!
You have been selected to create version 1.0 of the Twitzer app.

###Feature list

The app is very simple and does only contain a public timeline. 
You should fetch the timeline from their API and display all twitz in a list.
Every twitz contains a status message of less than 140 characters and some metadata about the user.
Information should be presented according to specification below.

###Specification

* Twitz should be presented in a list with each row showing twitz text, username and date of the twitz according to our specification. 
* Application should display a spinner (progressbar) while the feed is being loaded. 

* Unfortunately Twitzer API is in early development, therefore appropriate safety measures are required when parsing the timeline. 

* Date should be formatted as: 
If date is today the app should display “today”. 
If date is earlier than today, it should display it as “Sep 28”

* App is only for mobile (no tablet), portrait mode only.
