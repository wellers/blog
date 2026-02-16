namespace Blog.Interfaces;

public interface IHaveKey
{
	object Key { get; set; }
	string KeyName { get; }
}
