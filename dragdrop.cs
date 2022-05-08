using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
    [STAThread]
    static public void Main ()
    {
        Application.Run (new Form1 ());
    }
    private TextBox tb;
    public Form1 ()
    {
        StartPosition = FormStartPosition.CenterScreen;
        Size = new Size(800, 600);
        MaximizeBox = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        TopMost = true;
        Text = "Yes";
        tb = new TextBox();
        // tb.Text = "hello world";
        tb.AcceptsReturn = true;
        tb.WordWrap = true;
        tb.Width = Width - 10;
        tb.Height = Height - 10;
        tb.ScrollBars = ScrollBars.Vertical;
        // tb.Location = 
        tb.Multiline = true;

        tb.AllowDrop = true;
        tb.DragEnter += new DragEventHandler(tb_DragEnter);
        tb.DragDrop += new DragEventHandler(tb_DragDrop);
        Controls.Add (tb);
    }
 
    private void tb_DragEnter(object sender, DragEventArgs e){
        if (e.Data.GetDataPresent(DataFormats.FileDrop)){
            e.Effect = DragDropEffects.Move;
        }
        else{
            e.Effect = DragDropEffects.None;
        }
    }

    private void tb_DragDrop(object sender, DragEventArgs e){
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        // this.Text += files + "\n";
        // if (Path.GetExtension(strPath) == ".sln")
        for(int i=0; i<files.Length; i++){
            tb.Text += files[i] + "\r\n";
            // Console.WriteLine(files[i]);
        }
    }
}

// C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe hello.cs
// C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /target:winexe hello.cs -r:System.Windows.Forms.dll -r:System.Drawing.dll
