using System;
using DevExpress.Xpo;

public class Category  : XPObject {
    public Category()
        : base() { }

    public Category (Session session)
        : base(session) { }

    public override void AfterConstruction() {
        base.AfterConstruction();
    }

    [Association("Category-Articles")]
    public XPCollection<Article> Articles {
        get { return GetCollection<Article>("Articles"); }
    }

    private string _Name;
    public string Name {
        get { return _Name; }
        set { SetPropertyValue("Name", ref _Name, value); }
    }
}

