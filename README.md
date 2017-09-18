# Ef.BulkInsert

This is a project to demonstrate how to do bulk inserts with EntityFramework using the [SqlBulkCopy](https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlbulkcopy%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396) class. This is inspired by [this](http://weblogs.thinktecture.com/pawel/2016/04/entity-framework-using-sqlbulkcopy-and-temp-tables.html) blog post on using SqlBulkCopy for high performance querying. 

Core to this solution is the custom implementation of the [IDataReader](https://msdn.microsoft.com/en-us/library/system.data.idatareader%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396) interface. [Mike Goatley](http://www.developerfusion.com/profile/mikegoatly/) has a very detailed explanation in implementing such custom IDataReader implementation [here](http://www.developerfusion.com/article/122498/using-sqlbulkcopy-for-high-performance-inserts/); which I copied most of the code. 

I also referred to [this EntityFramework.BulkInsert](https://github.com/Thorium/EntityFramework.BulkInsert) repository on how it's implemented as an extension.
