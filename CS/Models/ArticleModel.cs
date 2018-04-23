using System;
using DevExpress.Xpo;

public class Article : XPObject {
    public Article(Session session)
        : base(session) { }

    private Category _Category;
    [Association("Category-Articles")]
    public Category Category {
        get { return _Category; }
        set { SetPropertyValue("Category", ref _Category, value); }
    }

    private string _Name;
    public string Name {
        get { return _Name; }
        set { SetPropertyValue("Name", ref _Name, value); }
    }
}

