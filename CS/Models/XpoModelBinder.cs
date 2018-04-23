using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using System.Web.Mvc;
using DevExpress.Xpo.Metadata;
using DevExpress.Xpo;
using System.ComponentModel;

public class XpoModelBinder : DevExpressEditorsBinder {
    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType) {
        IXpoController xpoController = controllerContext.Controller as IXpoController;

        if (xpoController == null)
            throw new InvalidOperationException("The controller does not support IXpoController interface");

        XPClassInfo classInfo = xpoController.XpoSession.GetClassInfo(modelType);
        ValueProviderResult result = bindingContext.ValueProvider.GetValue(classInfo.KeyProperty.Name);

        return result == null ? classInfo.CreateNewObject(xpoController.XpoSession) :
            xpoController.XpoSession.GetObjectByKey(classInfo, result.ConvertTo(classInfo.KeyProperty.MemberType));
    }
}