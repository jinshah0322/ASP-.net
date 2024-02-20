Steps of implementation

1) Run the script file to generate the Database which contains all the tables.
2) Open Q&AManagement folder which contains the solution of the project.
3) On Opening the folder there will be a solution file Q&AManagement.sln which is to be opened on opening it visual studio will be opened.
4) If EntityFramework is no installed then to install it right click on Q&AManagement and click manage nuGet Packages.
5) Once Nuget Packages are opened click on browse to install EntityFramework.
6) Now you have to make changes in web config file by 
   <connectionStrings>
	<add name="TaskContext" connectionString="Data Source=DESKTOP-2JN7IG8\SQLEXPRESS;Initial Catalog=TodoListMVC;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>

Above Data Source is mentioned which contains DESKTOP-2JN7IG8 so instead of this write your Data Source which you will get from SSMS so copy it and paste here.

7)Now go to models click on new items and click on data panel which contains ADO.net entity framework model and import the database using db first approach.

8)After model are inserted open users.cs file of model and apply Required validation on Username,password,email and role additionally apply regex on email and password whch are as follows:
[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage ="Enter Strong Password")]
[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage ="Invalid Email Address")]

8) Now you are good to go run the project by clicking the run button or by clicking f5

Note that there is a admin user whose credentials are as follows:
email:admin@gmail.com
password:Admin@123

you can create student and teacher user by your self.

If you are logging in through u will be redirected to Student Index page and same goes for Admin and Teacher

There are 3 modules Admin,Student and Teacher which are self explainatory from the UI.