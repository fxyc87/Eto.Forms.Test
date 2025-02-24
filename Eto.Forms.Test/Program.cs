using Eto.Drawing;

using Gtk;

using Pango;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Eto.Forms.Test
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Application(Eto.Platforms.Gtk).Run(new frm());
        }
		public class test { 
			public int ID { get; set; }
			public string Name { get; set; }
			public int Age { get; set; }
			public bool IsAdmin { get; set; }
		}
		static GridView grid;
		static List<test> dat;
        class frm : Form {
			public frm()
			{
				// ���ô������
				Title = "Eto.Forms ʾ��";

				// ���ô����С
				ClientSize = new Size(400, 300);

				var layout = new DynamicLayout();
				layout.DefaultSpacing = new Size(5, 5);
				layout.Padding= new Padding(20,20,20,20);
				layout.BeginVertical();
				layout.AddRow(new GridView());
				layout.EndBeginVertical();
				//layout.AddSpace(true, true);
				//layout.AddRow(new Panel() { Height = 20 });
				layout.AddRow(new Label() { Text = "����" }, new TextBox() { Text = "test1", ID = "txt" });
				layout.AddRow(new Label() { Text = "����" }, new TextBox() { Text = "test1" });
				layout.AddRow(null);

				layout.BeginVertical();
				var b = new StackLayout();
				b.Spacing = 5;b.Orientation = Orientation.Horizontal;
				b.Items.Add(new Button() { Text = "���" });
				b.Items.Add(new Button() { Text = "ɾ��" });
				b.Items.Add(new Button() { Text = "����" });
				layout.AddRow(b);
				layout.EndBeginVertical();

				layout.BeginVertical();
				var l = new PixelLayout();
				l.Add(new Button() { Text = "���" }, 0, 0);
				l.Add(new Button() { Text = "���" }, 20, 20);
				layout.AddRow(l);
				layout.EndBeginVertical();


				grid = layout.FindChild<GridView>();
				grid.Columns.Add(new GridColumn() { HeaderText = "���" ,DataCell=new TextBoxCell() { Binding = Binding.Property<test,string>(n=>n.ID.ToString()) } });
				grid.Columns.Add(new GridColumn() { HeaderText = "����", DataCell = new TextBoxCell() { Binding = Binding.Property<test, string>(n => n.Name )}, Editable = true });
				grid.Columns.Add(new GridColumn() { HeaderText = "����", DataCell = new TextBoxCell() { Binding = Binding.Property<test, string>(n => n.Age.ToString()) } });
				grid.Columns.Add(new GridColumn() { HeaderText = "����Ա", DataCell = new CheckBoxCell() { Binding = Binding.Property<test, bool?>(n => n.IsAdmin) },Editable=true });
				dat = new List<test>();
				dat.AddRange(new test[] {
					new test(){ID=1,Name="����",Age=18,IsAdmin=true},
					new test(){ID=2,Name="����",Age=19,IsAdmin=false},
					new test(){ID=3,Name="����",Age=20,IsAdmin=true},
					new test(){ID=4,Name="������������",Age=21,IsAdmin=false},
					new test(){ID=5,Name="Ǯ��",Age=22,IsAdmin=true},
					new test(){ID=6,Name="���",Age=23,IsAdmin=false},
					new test(){ID=7,Name="�ܾ�",Age=24,IsAdmin=true},
				});

				grid.DataStore = dat;
				grid.CellEdited += (s, e) => {
				};
				// ���ô�������
				Content = layout;
				layout.FindChild<TextBox>("txt").TextChanged += (s, e) => { 
					
					this.Title = ((TextBox)s).Text;
				
				};
			}
        }
    }
}