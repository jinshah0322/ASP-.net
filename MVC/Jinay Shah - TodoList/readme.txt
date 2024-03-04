Steps of implementation

1) Run the script file to generate the Database which contains all the tables.
2) Open TodoListDBFirst or TodoListProject both are projects of TodoList performed with different approaches DBFirst and CodeFirst respectively.
3) On Opening any of the folder there will be a solution file which is to be opened on opening it visual studio will be opened.
4) If EntityFramework is no installed then to install it right click on ToDoListProject or TodoListDBFirst which ever project is opened and click manage nuGet Packages.
5) Once Nuget Packages are opened click on browse to install EntityFramework.
6) Now you have to make changes in web config file by 
   <connectionStrings>
	<add name="TaskContext" connectionString="Data Source=DESKTOP-2JN7IG8\SQLEXPRESS;Initial Catalog=TodoListMVC;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>

Above Data Source is mentioned which contains DESKTOP-2JN7IG8 so instead of this write your Data Source which you will get from SSMS so copy it and paste here.
7) Now you are good to go run the project by clicking the run button or by clicking f5

Follow same steps for other project too.