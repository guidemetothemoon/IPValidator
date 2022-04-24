# IPValidator
This is a small app that provides information about IP addresses provided in HTTP requests. 
Can be useful when testing proxy solutions or IP whitelisting.

Every time a change is done to the repo, a container image is being built and pushed to public Docker repository. You can easily pull and run the image locally with:
```docker pull guidemetothemoon/ipvalidator:latest```
```docker run -d -p 3000:80 guidemetothemoon/ipvalidator:latest```
Once the app is up and running, you can validate HTTP request client IP by calling ```my_app_url/ip``` .
