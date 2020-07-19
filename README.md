## Description
The goal is to create a permissions based authorization solution with roles.
By default Identity provides  two types of authorization 
- Policy based
- Roles based

This solution attempts to hack the claims system provided by identity to make it store permissions By using :
- The user claims to store custom permissions
- Role claims to store each role  specific permissions.
- Use custom filter for Controllers/ApiControllers like this

        [HasPermissionForAction(Permission = Permissions.CanRead, Entity = Entities.About)]


## Get started
1) Clone the repo

        git clone https://github.com/Amine-Smahi/Identity.Permissions.PoC

2) Navigate to the repo folder

        cd Identity.Permissions.PoC

3) Apply migrations

        dotnet ef database update

4) Run the project

        dotnet run
        
## Test the project
You should see a authorization warning as you navigate to the privacy and about pages.
- Now create an account and navigate to claims, this will create an admin role and add you to it.
So now that you have the admin permissions navigate to the privacy page and you should see the page.
- The about page still shows a permission warning, that can be solved by navigating to get AddPermission route, this will give you a custom permission to navigate to about page
- To get the list of permissions just navigate to the GetPermissions route

## Note
This is just a PoC which means this is my way of hacking identity, Feel free to open issue or make a pull request.
