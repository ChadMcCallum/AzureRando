AzureRando
==========

A cards against humanity twitter bot, kind of?

It's actually a nancy web service that will write using TweetSharp.TwitterService to whatever account 
you have the appropriate keys for.  I did it this way because I wanted to create something that I could automate every 30
minutes or so to post something new to twitter.  So, I have this published to Azure, and have an account at setcronjob.com
making a post request against this one endpoint every 30 minutes.

The files are taken from cardsagainsthumanity.com: http://www.cardsagainsthumanity.com/wcards.txt, 
http://www.cardsagainsthumanity.com/bcards.txt, http://www.cardsagainsthumanity.com/bcards1.txt, 
http://www.cardsagainsthumanity.com/bcards2.txt
