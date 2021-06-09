using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.CodeDom;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace ResourceWriterTest
{
    [Designer(typeof(LocalizerDesigner))]
    [DesignerSerializer(typeof(LocalizerSerializer), typeof(CodeDomSerializer))]
    public class CustomUserControl2 : UserControl
    {
        private Button button1;

        private void InitializeComponent()
        {
            //System.ComponentModel.ComponentResourceManager resources 
            //    = new System.ComponentModel.ComponentResourceManager(typeof(CustomUserControl2));
            MyResourceManager resources
                = new MyResourceManager(typeof(CustomUserControl2));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // CustomUserControl2
            // 
            this.Controls.Add(this.button1);
            this.Name = "CustomUserControl2";
            this.ResumeLayout(false);

        }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/15222528/net-winforms-localization-replacing-componentresourcemanager
    /// https://docs.microsoft.com/ko-kr/dotnet/api/system.resources.resourcewriter?redirectedfrom=MSDN&view=net-5.0
    /// https://stackoverflow.com/questions/4034665/dynamically-adding-resource-strings
    /// https://docs.microsoft.com/en-us/dotnet/framework/resources/working-with-resx-files-programmatically
    /// </summary>
    [Designer(typeof(LocalizerDesigner))]
    [DesignerSerializer(typeof(LocalizerSerializer), typeof(CodeDomSerializer))]
    public class Localizer : Component
    {

        public static void GetResourceManager(Type type, out ComponentResourceManager resourceManager)
        {
            resourceManager = new MyResourceManager(type);
        }

    }



    public class MyResourceManager : ComponentResourceManager
    {
        public MyResourceManager(Type type) : base(type)
        {
        }

        public virtual void ApplyResources(
            object value
            , string objectName
            , string sText)
        {
            base.ApplyResources(value, objectName);


        }


    }


    public class LocalizerSerializer : CodeDomSerializer
    {
        public override object Deserialize(IDesignerSerializationManager manager, object codeDomObject)
        {
            CodeDomSerializer baseSerializer = (CodeDomSerializer)
                manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));
            return baseSerializer.Deserialize(manager, codeDomObject);
        }

        public override object Serialize(IDesignerSerializationManager manager, object value)
        {
            CodeDomSerializer baseSerializer =
                (CodeDomSerializer)manager.GetSerializer(typeof(Component), typeof(CodeDomSerializer));

            object codeObject = baseSerializer.Serialize(manager, value);

            if (codeObject is CodeStatementCollection)
            {
                CodeStatementCollection statements = (CodeStatementCollection)codeObject;
                CodeTypeDeclaration classTypeDeclaration =
                    (CodeTypeDeclaration)manager.GetService(typeof(CodeTypeDeclaration));
                CodeExpression typeofExpression = new CodeTypeOfExpression(classTypeDeclaration.Name);
                CodeDirectionExpression outResourceExpression = new CodeDirectionExpression(
                    FieldDirection.Out, new CodeVariableReferenceExpression("resources"));
                CodeExpression rightCodeExpression =
                    new CodeMethodInvokeExpression(new CodeTypeReferenceExpression("LocalizationTest.Localizer"), "GetResourceManager",
                    new CodeExpression[] { typeofExpression, outResourceExpression });

                statements.Insert(0, new CodeExpressionStatement(rightCodeExpression));
            }
            return codeObject;
        }
    }

    public class LocalizerDesigner : ComponentDesigner
    {
        public override void Initialize(IComponent c)
        {
            base.Initialize(c);
            var dh = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (dh == null)
                return;

            var innerListProperty = dh.Container.Components.GetType().GetProperty("InnerList", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.FlattenHierarchy);
            var innerList = innerListProperty.GetValue(dh.Container.Components, null) as System.Collections.ArrayList;
            if (innerList == null)
                return;
            if (innerList.IndexOf(c) <= 1)
                return;
            innerList.Remove(c);
            innerList.Insert(0, c);

        }
    }




}