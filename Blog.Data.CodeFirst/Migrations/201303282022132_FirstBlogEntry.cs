namespace Blog.Data.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstBlogEntry : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO BlogEntries (Title, Entry, PostedDate)
                SELECT 'Syntactic sugar: ""one lump or two?""',
                '<div><p>This is my first blog post. Hooray! So I thought, for the contents of my first post, I would write about some of the features I like about the Dot Net framework, in particular C# syntactic sugar.</p><p>Quite simply, syntactic sugar is syntax within a programming language that is designed to make things easier to read or to express.</p><p>Some examples of syntactic sugar are detailed below.</p></div><div><br /><p><strong>Auto-properties</strong></p><p>Automatic properties are great. Removing the need to add a backing field to hold data.</p><pre class=''brush: csharp''>
// property with a backing field
private int _id;
public int ID
{
	get 
	{ 
		return _id; 
	}
	set 
	{
		_id = value; 
	}
}

// this can be simple rewritten to
public int ID
{
	get;
	set;
}
</pre><p>What is really great is when you only want the property''s ''getter''; to be public. You can write your property as follows.</p><pre class=''brush: csharp''>
public int ID
{
	get;
	private set;
}
</pre><p>This property is now immutable and therefore can only be set from within a class that contains it.</p></div><div><br /><p><strong>LINQ (Language Integrated Query)</strong></p><p>LINQ statements are extensions to Dot Net that add query-like capabilities. This can be extremely powerful when used in conjunction with collection. An example of this is shown below.</p><pre class=''brush: csharp''>
    var items = new List&ltItem&gt();

    // foreach for projecting the property ID into a new collection
    var ids = new List&ltint&gt();
    foreach(var x in items)
    {
        ids.Add(x.ID);
    }

    // this can be easily rewritten as...
    var ids = items.Select(x =&gt new { x.ID });</pre></div><div><br /><p><strong>Object and Collection initialisers</strong></p><p>Object initialisers are a great way of instantiating objects, with their members set, without the tediousness of writing member assignments. An example is shown below.</p><pre class=''brush: csharp''>
    // with the following class
    public class Person
    {
        public int ID { get; set; }
        public int Name { get; set; }
    }

    // we can instantiate an object and set its properties as follows
    var person = new Person();
    person.ID = 1;
    person.Name = ''Paul'';

    // or we can do this
    var person = new Person { ID = 1, Name = ''Paul'' };</pre><p>Collections can also be initialised, with their members set, using a similar syntax.</p><pre class=''brush: csharp''>
    // initialise collection and add members
    var dictionary = new Dictionary&ltint, string&gt();
    dictionary.Add(1,''Foo'');
    dictionary.Add(2,''Bar'');
    
    // we can rewrite the above to
    var dictionary = new Dictionary&ltint, string&gt 
    {
        { 1, ''Foo'' }, 
        { 2, ''Bar'' } 
    };</pre></div><div><p>I may continue to expand on this post, for my next post, and go into other syntactic sugar features of Dot Net.</p></div>',
                GETDATE()
            ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM BlogEntries WHERE Title = 'Syntactic sugar: ''one lump or two?'''");
        }
    }
}
