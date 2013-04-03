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
                SELECT 'Syntactic sugar: &quot;one lump or two?&quot;',
                '&lt;div&gt;&lt;p&gt;This is my first blog post. Hooray! So I thought, for the contents of my first post, I would write about some of the features I like about the Dot Net framework, in particular C# syntactic sugar.&lt;/p&gt;&lt;p&gt;Quite simply, syntactic sugar is syntax within a programming language that is designed to make things easier to read or to express.&lt;/p&gt;&lt;p&gt;Some examples of syntactic sugar are detailed below.&lt;/p&gt;&lt;/div&gt;&lt;div&gt;&lt;br /&gt;&lt;p&gt;&lt;strong&gt;Auto-properties&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;Automatic properties are great. Removing the need to add a backing field to hold data.&lt;/p&gt;&lt;pre class=&quot;brush: csharp&quot;&gt;
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
&lt;/pre&gt;&lt;p&gt;What is really great is when you only want the property&#39;s &#39;getter&#39; to be public. You can write your property as follows.&lt;/p&gt;&lt;pre class=&quot;brush: csharp&quot;&gt;
public int ID
{
	get;
	private set;
}
&lt;/pre&gt;&lt;p&gt;This property is now immutable and therefore can only be set from within a class that contains it.&lt;/p&gt;&lt;/div&gt;&lt;div&gt;&lt;br /&gt;&lt;p&gt;&lt;strong&gt;LINQ (Language Integrated Query)&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;LINQ statements are extensions to Dot Net that add query-like capabilities. This can be extremely powerful when used in conjunction with collection. An example of this is shown below.&lt;/p&gt;&lt;pre class=&quot;brush: csharp&quot;&gt;
    var items = new List&amp;ltItem&amp;gt();

    // foreach for projecting the property ID into a new collection
    var ids = new List&amp;ltint&amp;gt();
    foreach(var x in items)
    {
        ids.Add(x.ID);
    }

    // this can be easily rewritten as...
    var ids = items.Select(x =&amp;gt new { x.ID });&lt;/pre&gt;&lt;/div&gt;&lt;div&gt;&lt;br /&gt;&lt;p&gt;&lt;strong&gt;Object and Collection initialisers&lt;/strong&gt;&lt;/p&gt;&lt;p&gt;Object initialisers are a great way of instantiating objects, with their members set, without the tediousness of writing member assignments. An example is shown below.&lt;/p&gt;&lt;pre class=&quot;brush: csharp&quot;&gt;
    // with the following class
    public class Person
    {
        public int ID { get; set; }
        public int Name { get; set; }
    }

    // we can instantiate an object and set its properties as follows
    var person = new Person();
    person.ID = 1;
    person.Name = &quot;Paul&quot;;

    // or we can do this
    var person = new Person { ID = 1, Name = &quot;Paul&quot; };&lt;/pre&gt;&lt;p&gt;Collections can also be initialised, with their members set, using a similar syntax.&lt;/p&gt;&lt;pre class=&quot;brush: csharp&quot;&gt;
    // initialise collection and add members
    var dictionary = new Dictionary&amp;ltint, string&amp;gt();
    dictionary.Add(1,&quot;Foo&quot;);
    dictionary.Add(2,&quot;Bar&quot;);
    
    // we can rewrite the above to
    var dictionary = new Dictionary&amp;ltint, string&amp;gt 
    {
        { 1, &quot;Foo&quot; }, 
        { 2, &quot;Bar&quot; } 
    };&lt;/pre&gt;&lt;/div&gt;&lt;div&gt;&lt;p&gt;I may continue to expand on this post, for my next post, and go into other syntactic sugar features of Dot Net.&lt;/p&gt;&lt;/div&gt;',
                GETDATE()
            ");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM BlogEntries WHERE Title = 'Syntactic sugar: &quot;one lump or two?&quot;'");
        }
    }
}
