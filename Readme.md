# How to Start/Stop EC2 instances with Lambda function.

You need to set your instances IDs to Lambda environment variable.
Like this:
![image](https://user-images.githubusercontent.com/54844737/98463382-36384800-21fe-11eb-882c-333615c45d74.png)
You have to split the instance IDs by comma.

Before deploying, you have to build this project at least once.

At last, you can attach EventBridge (CloudWatch Events).