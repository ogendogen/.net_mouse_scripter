using System.Windows.Forms;
using System.Drawing;

namespace mouse_scripter
{
    public class MyMouse
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        /*private Cursor cursor;

        public MyMouse(Cursor cursor)
        {
            this.cursor = cursor;
        }*/

        //This simulates a left mouse click
        public static void LeftMouseClick()
        {
            /*SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);*/
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void LeftDoubleClick()
        {
            LeftMouseClick();
            LeftMouseClick();
        }

        public static void RightMouseClick()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
        }

        public static void DragNDrop(int dragx, int dragy, int dropx, int dropy)
        {
            SetCursorPos(dragx, dragy);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            SetCursorPos(dropx, dropy);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void GetCursorPos(out int x, out int y)
        {
            x = Cursor.Position.X;
            y = Cursor.Position.Y;
        }

        public static Point GetCursorPos()
        {
            return Cursor.Position;
        }
    }
}
