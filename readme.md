Ex Libris Student Portal Sample App - My Library
================================================

Introduction
------------

We're going to use the new Alma REST APIs to build a basic student portal with a few features to help get you started with Alma APIs.

The application does the following:
* Library card- we'll display some basic student information and allow users to update a few key data elements
* Requests- we'll show a list of the student's requests, and allow the user to cancel them
* Rooms- we probably won't get to this in the demo, but these applications always have three sections, so we needed to have a third!

It's meant to demo how to:
* Created an application to get an API Key
* Integrated with an authentication system to get an Alma identifier
* Made GET calls and received JSON formatted data, including arrays
* Made PUT and DELETE calls to Alma APIs to update and delete objects

About the App
-------------
The application is written in C# and uses the new Alma APIs described [here](https://developers.exlibrisgroup.com/alma/apis). See also an extensive blog entry on this application [here](https://developers.exlibrisgroup.com). 