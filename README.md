# Interest Rate API

This simple API has only one endpoint that returns a fixed interest rate defined in the source code. The value returned here is used by the FutureValueApi to calculate the future value of an amount of money.

The project has three layers: Data, Domain, and API. The Data layer has just one repository that returns a fixed interest rate. I am using a repository here to make it easy to start using a database instead of the fixed interest rate value (if we want to). 

The Domain layer contains a model for interest rate and a service which consumes the repository. Finally, the API layer just exposes the service to the external world through a controller.

## Outline

 - [Installation](#installation)
 - [Building APIs](#building-apis)
 - [Quick Reference](#quick-reference)
 - [Deploying to Heroku](#deploying)

## Libraries

This project is using some libraries and frameworks:

 - [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
 - [Docker](https://docs.docker.com/)
 - [MSTest](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=visualstudiosdk-2022)
 - [Swagger](https://swagger.io/)

## Running locally

First, clone the project to your local machine using the following command:

```
git clone https://github.com/ozmartins/Osm.InterestRate.git
```

Then, to enter into the project directory, type into the terminal:

```
cd Osm.InterestRate\Osm.InterestRate.Api
```
Finally, run the app using the command shown below:

```
dotnet run --project Osm.InterestRate.Api.csproj
```

Now, the is running and you can try it accessing the URL https://localhost:5001

### GitHub

The first step is to register a [github account](https://github.com/) (if you don't have one yet) which allows you
to store your code for free on the github servers.

You probably need to [upload your ssh key](https://help.github.com/articles/generating-ssh-keys) to Github
in order to get or push repositories:

```bash
$ pbcopy < ~/.ssh/id_rsa.pub
```

If that command fails with a file not found, run `$ ssh-keygen -t rsa -C "your_email@example.com"` to generate your SSH key.

Next, go to your [ssh keys](https://github.com/settings/ssh) and paste the contents of your clipboard.

### Fork and Clone

Now we need to **fork this repository** to your own account at <https://github.com/thecodepath/server-api-template>.
You can do that by clicking "Fork" on the top right.

Next, you want to clone your version of this repository locally:

```bash
$ git clone git@github.com:myusername/server-api-template.git
```

**Note:** Be sure to replace `myusername` with your own bitbucket username above.

### Setup

Run the task to install dependencies:

```bash
$ bundle
```

When this is finished, let's prepare this as a new git repository (for storing code):

```bash
$ rm -rf .git
$ git init
$ git commit -am "initial commit of my app"
$ git remote add origin git@bitbucket.org:myusername/server-api-template.git
$ git push origin master --force
```

**Note:** Be sure to replace `myusername` with your own bitbucket username above for remote.

Now setup your local database for use on your computer:

```bash
$ rake db:migrate db:test:prepare
```

### Running

Once you are setup, be sure to start your Rails application:

```bash
$ rails server
```

This starts your API application at <http://localhost:3000> so you
can try it locally. Try going to <http://localhost:3000/api/v1/sessions>.

## Quick Reference

### Key files

Key files to edit:

  - "app/api/endpoints/*" - Adding endpoints and APIs
  - "db/migrate" - Defining the model attributes in the database
  - "app/models" - Defining any additional model information
  - "test/api"   - Defining tests for your APIs (if needed)

### Key URLs

Few URLs to note (once rails server is running):

  - "/api/sessions" - Simple endpoint that returns text
  - "/rails/routes" - See a list of common rails routes
  - "/users/sign_in" - Login (or register) a user
  - "/admin" - Admin panel for viewing database content

### Request Methods

As a rule of thumb, the request method to pick is as follows:

|Method|Description|Example|
| ------ | ------ | ----- |
|get|For returning resources from read-only endpoint|Get user tweets|
|post|For creating new resources|Create new tweet|
|put|For updating an existing resource|Editing a user's password|
|delete|For deleting a resource|Trashing a tweet|


### Response Status Codes

Another thing to notice is API response `status` codes, as a rule of thumb:

|Status|Description|Example|
| ------ | ------ | ----- |
|200|Success|Retrieved list of user tweets|
|201|Created|Create new tweet|
|400|Bad request|Invalid email for registration|
|401|Unauthorized|No permission or not logged in|
|500|Error|Exception happened on server|

## Deploying

The easiest way to deploy your APIs is to use [Heroku](http://heroku.com).

### Register for an account

First, register yourself a (free) Heroku account at <https://api.heroku.com/signup>. This is
your developer account that can contain any number of free applications.

### Create app

Run the following command in the terminal to create your app:

```bash
$ gem install heroku
$ heroku login
$ heroku create myappname
```

**Note:** Be sure to replace `myappname` with your own application name above.

Be sure to enter your username and password as defined when you created your Heroku account earlier.

### Deploy App

Next it is time to deploy your application:

```bash
$ git push heroku master
```

You may need to type 'yes' when it asks if you want to continue. At this point you should see
Heroku deploying your application to the internet:

```
Warning: Permanently added the RSA host key for IP address '50.19.85.156' to the list of known hosts.
Counting objects: 206, done.
Delta compression using up to 8 threads.
Compressing objects: 100% (184/184), done.
Writing objects: 100% (206/206), 53.24 KiB, done.
Total 206 (delta 70), reused 0 (delta 0)

-----> Ruby/Rails app detected
-----> Installing dependencies using Bundler version 1.3.2
...
```

Wait while this command sets up your application on their servers. Once this is finished, it is time to setup our application on their servers:

### Verify App

Now you can open the url to your app with:

```bash
$ heroku open
```

and now you can visit `/api/vi/sessions` in your browser to confirm this app is running if you see:

```
"This is a sign that the API endpoints are configured"
```

### Wrapping Up ###

At this point you have a deployed API application. If you make changes to your app, simply run:

```bash
$ git add .
$ git commit -am "describe my changes here"
$ git push heroku master
```

and the updated code will be pushed to Heroku accordingly.
