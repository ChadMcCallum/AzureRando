AzureRando
==========

A cards against humanity twitter bot, kind of?

It's actually a nancy web service that will write using TweetSharp.TwitterService to whatever account 
you have the appropriate keys for.  I did it this way because I wanted to create something that I could automate every 30
minutes or so to post something new to twitter.  So, I have this published to Azure, and have an account at setcronjob.com
making a post request against this one endpoint every 30 minutes.

This won't actually work unless you create a "mytwittersettings.xml" file in the same directory as the web service - I 
did this so that I could ignore the file in git and not accidentially upload my app keys.  It should follow the following format:

<appSettings>
  <add key="consumerKey" value="from-twitter" />
  <add key="consumerSecret" value="from-twitter" />
  <add key="token" value="from-twitter" />
  <add key="tokenSecret" value="from-twitter" />
  <add key="password" value="whatever you want it to be" />
</appSettings>

The last value, "password", is used to filter all post requests to the web service, so that people don't just randomly spam the endpoint and cause it to flood twitter.  That same value needs to be sent as part of the post request for the request to be validated.

The card contents are taken from cardsagainsthumanity.com: http://www.cardsagainsthumanity.com/wcards.txt, 
http://www.cardsagainsthumanity.com/bcards.txt, http://www.cardsagainsthumanity.com/bcards1.txt, 
http://www.cardsagainsthumanity.com/bcards2.txt
