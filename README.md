# Captcha Creation In MVC

I have used two approach to build captcha.

1. I have used simple class 'captchaGenerator'
2.  Another one is using ActionResult, where I have created bitmap captcha image in abstract method inherited from ExecuteResult.


I am using bitmap,Graphics classes. I have created a random digit to put in bitmap image object before disposing. 

I have added random generated no string in session. On post back I am verifying captcha entered by user. 
