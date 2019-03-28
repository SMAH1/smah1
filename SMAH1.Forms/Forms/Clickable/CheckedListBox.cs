using SMAH1.ExtensionMethod;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SMAH1.Forms.Clickable
{
    public partial class CheckedListBox : UserControl
    {
        private Collections.List<Label> labels = new Collections.List<Label>();

        #region class
        protected internal class InternalObject
        {
            public object Object { get; set; }
            public CheckBox Control { get; set; }
        }

        public class InternalObjectCollecton : System.Collections.IEnumerator, System.Collections.IEnumerable
        {
            CheckedListBox parent = null;
            System.Collections.Generic.List<InternalObject> items = new System.Collections.Generic.List<InternalObject>();

            public InternalObjectCollecton(CheckedListBox par)
            {
                parent = par;
            }

            public int Count { get { return items.Count; } }
            public object this[int index]
            {
                get { return items[index].Object; }
                set
                {
                    items[index].Object = value;
                    items[index].Control.Text = (value != null ? value.ToString() : string.Empty);
                }
            }

            internal CheckBox Controls(int index)
            {
                return items[index].Control;
            }

            public int Add(object obj)
            {
                return Add(obj, false);
            }

            public int Add(object obj, bool _checked)
            {
                return Add(obj, false, _checked, CheckState.Unchecked, false);
            }

            public int Add(object obj, CheckState state)
            {
                return Add(obj, true, false, state, true);
            }

            private int Add(object obj, bool threeState, bool _checked, CheckState state, bool setState)
            {
                InternalObject io = new InternalObject
                {
                    Object = obj,
                    Control = new CheckBox()
                    {
                        ThreeState = threeState,
                        Text = (obj != null ? obj.ToString() : string.Empty),
                        Tag = Guid.NewGuid(),
                        Location = new Point(0, 0),
                        RightToLeft = parent.RightToLeft,
                        AutoSize = true,
                        Margin = new Padding(0)
                    }
                };
                if (setState)
                    io.Control.CheckState = state;
                else
                    io.Control.Checked = _checked;
                io.Control.CheckedChanged += new EventHandler(Control_CheckedChanged);
                io.Control.CheckStateChanged += new EventHandler(Control_CheckStateChanged);

                items.Add(io);
                parent.UpdateItems();
                return items.Count - 1;
            }

            public void InsertAt(int index, object obj)
            {
                InsertAt(index, obj, false);
            }

            public void InsertAt(int index, object obj, bool _checked)
            {
                InsertAt(index, obj, false, _checked, CheckState.Unchecked, false);
            }

            public void InsertAt(int index, object obj, CheckState state)
            {
                InsertAt(index, obj, true, false, state, true);
            }

            private void InsertAt(int index, object obj, bool threeState, bool _checked, CheckState state, bool setState)
            {
                InternalObject io = new InternalObject
                {
                    Object = obj,
                    Control = new CheckBox()
                    {
                        ThreeState = threeState,
                        Text = (obj != null ? obj.ToString() : string.Empty),
                        Tag = Guid.NewGuid(),
                        Location = new Point(0, 0),
                        RightToLeft = parent.RightToLeft,
                        AutoSize = true,
                        Margin = new Padding(0)
                    }
                };
                if (setState)
                    io.Control.CheckState = state;
                else
                    io.Control.Checked = _checked;

                io.Control.CheckedChanged += new EventHandler(Control_CheckedChanged);
                io.Control.CheckStateChanged += new EventHandler(Control_CheckStateChanged);

                items.Insert(index, io);
                parent.UpdateItems();
            }

            public void RemoveAt(int index)
            {
                RemoveAtInternal(index);
                parent.UpdateItems();
            }

            private void RemoveAtInternal(int index)
            {
                var i = items[index];
                items.RemoveAt(index);

                i.Control.CheckedChanged -= new EventHandler(Control_CheckedChanged);
                i.Control.CheckStateChanged -= new EventHandler(Control_CheckStateChanged);

                i.Control.Dispose();
                i.Control = null;
            }

            public void Clear()
            {
                int i = 0, j = items.Count;
                for (; i < j; i++)
                    RemoveAtInternal(i);
                parent.UpdateItems();
            }

            void Control_CheckStateChanged(object sender, EventArgs e)
            {
                Guid g = (Guid)((CheckBox)sender).Tag;
                for (int i = 0; i < items.Count; i++)
                    if (((Guid)items[i].Control.Tag) == g)
                    {
                        parent.OnCheckStateChanged(i);
                        break;
                    }
            }

            void Control_CheckedChanged(object sender, EventArgs e)
            {
                Guid g = (Guid)((CheckBox)sender).Tag;
                for (int i = 0; i < items.Count; i++)
                    if (((Guid)items[i].Control.Tag) == g)
                    {
                        parent.OnCheckedChanged(i);
                        break;
                    }
            }

            #region IEnumerator Members
            int position = -1;
            public bool MoveNext()
            {
                position++;
                return (position < items.Count);
            }
            public void Reset() { position = 0; }
            public object Current { get { return items[position].Object; } }
            #endregion

            #region IEnumerable Members
            public System.Collections.IEnumerator GetEnumerator()
            {
                return (System.Collections.IEnumerator)this;
            }
            #endregion
        }

        public class ThreeStateCollection
        {
            CheckedListBox parent = null;
            public ThreeStateCollection(CheckedListBox par) { this.parent = par; }
            public bool this[int index]
            {
                get { return parent.Items.Controls(index).ThreeState; }
                set { parent.Items.Controls(index).ThreeState = value; }
            }
        }
        public class CheckedCollection
        {
            CheckedListBox parent = null;
            public CheckedCollection(CheckedListBox par) { this.parent = par; }
            public bool this[int index]
            {
                get { return parent.Items.Controls(index).Checked; }
                set { parent.Items.Controls(index).Checked = value; }
            }
        }
        public class CheckStateCollection
        {
            CheckedListBox parent = null;
            public CheckStateCollection(CheckedListBox par) { this.parent = par; }
            public CheckState this[int index]
            {
                get { return parent.Items.Controls(index).CheckState; }
                set { parent.Items.Controls(index).CheckState = value; }
            }
        }
        #endregion


        [Browsable(false)] public ThreeStateCollection ItemThreeState { get; }
        [Browsable(false)] public CheckedCollection ItemChecked { get; }
        [Browsable(false)] public CheckStateCollection ItemCheckState { get; }
        [Browsable(false)] public InternalObjectCollecton Items { get; }
        [Browsable(false)] public Collections.List<int> GroupItemsCount { get; }

        public CheckedListBox()
        {
            InitializeComponent();
            Items = new InternalObjectCollecton(this);
            GroupItemsCount = new SMAH1.Collections.List<int>();
            GroupItemsCount.CountChanged += new EventHandler(List_CountChanged);

            ItemThreeState = new ThreeStateCollection(this);
            ItemChecked = new CheckedCollection(this);
            ItemCheckState = new CheckStateCollection(this);

            pnlLabelsInternal.AutoSize = true;
        }

        void List_CountChanged(object sender, EventArgs e)
        {
            UpdateItems();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            UpdateLabelWidth();
            UpdateLocationPanelInternal();
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            this.pnlLabelsExternal.RightToLeft = this.RightToLeft;
            this.pnlLabelsInternal.RightToLeft = this.RightToLeft;
            for (int i = 0; i < Items.Count; i++)
            {
                Items.Controls(i).RightToLeft = this.RightToLeft;
            }
            base.OnRightToLeftChanged(e);
            UpdateLocationPanelInternal();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            foreach (var lbl in labels)
            {
                lbl.BackColor = this.ForeColor;
                lbl.ForeColor = this.ForeColor;
            }
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
        }

        bool updateItem = true;
        public void BeginItemsChange() { updateItem = false; }
        public void EndItemsChange() { updateItem = true; UpdateItems(); }

        private void UpdateItems()
        {
            if (!updateItem)
                return;

            int indexItem = 0;
            int indexGroup = 0;
            int sum = -1;

            pnlLabelsInternal.Controls.Clear();
            pnlLabelsInternal.RowCount = 1;
            pnlLabelsInternal.ColumnCount = 1;

            foreach (var l in labels)
                l.Dispose();
            labels.Clear();

            if (indexGroup < GroupItemsCount.Count)
            {
                sum = GroupItemsCount[indexGroup];
                indexGroup++;
            }

            if (Items.Count > 0)
            {
                int r = -1;
                while (indexItem < Items.Count)
                {
                    if (sum == indexItem)
                    {
                        //Add separator
                        Label lbl = new Label
                        {
                            AutoSize = false,
                            BackColor = this.ForeColor,
                            ForeColor = this.ForeColor,
                            Size = new Size(50, 2),
                            Margin = new Padding(2, 5, 2, 5),
                            Anchor = AnchorStyles.Left | AnchorStyles.Right
                        };
                        labels.Add(lbl);

                        r++;
                        pnlLabelsInternal.Controls.Add(lbl, 0, r);

                        if (indexGroup < GroupItemsCount.Count)
                        {
                            sum += GroupItemsCount[indexGroup];
                            indexGroup++;
                        }
                        else
                            sum = -1;
                    }
                    else
                    {
                        r++;
                        pnlLabelsInternal.Controls.Add(Items.Controls(indexItem), 0, r);
                        indexItem++;
                    }
                }
            }

            UpdateLabelWidth();
            UpdateLocationPanelInternal();
        }

        private void UpdateLabelWidth()
        {
            bool bv = this.VerticalScroll.Visible;

            while (true)
            {
                int w = pnlLabelsExternal.Width;
                w -= 15;
                if (bv) w -= SystemInformation.VerticalScrollBarThumbHeight;

                foreach (var lbl in labels)
                    lbl.Size = new Size(w, lbl.Size.Height);

                if (bv == this.VerticalScroll.Visible)
                    break;
            }
        }

        private void UpdateLocationPanelInternal()
        {
            bool rtl = this.IsRTL();

            if (rtl)
            {
                int x = pnlLabelsExternal.Size.Width - pnlLabelsInternal.Size.Width - 3;
                if (x < 0)
                    x = 0;
                pnlLabelsInternal.Location = new Point(
                    x,
                    pnlLabelsInternal.Location.Y
                    );
            }
            else
            {
                pnlLabelsInternal.Location = new Point(0, 0);
            }
        }

        #region Events
        public class CheckeBoxEventArgs : EventArgs
        {
            internal CheckeBoxEventArgs(int index) { this.Index = index; }
            public int Index { get; }
        }

        #region CheckedChanged
        public delegate void CheckedChangedEventHandler(object sender, CheckeBoxEventArgs e);

        [Browsable(true)]
        [Description("Fire when checked of items is changed ")]
        public event CheckedChangedEventHandler CheckedChanged;

        private void OnCheckedChanged(int index)
        {
            CheckedChanged?.Invoke(this, new CheckeBoxEventArgs(index));
        }
        #endregion

        #region CheckStateChanged
        public delegate void CheckStateChangedEventHandler(object sender, CheckeBoxEventArgs e);

        [Browsable(true)]
        [Description("Fire when check state of items is changed ")]
        public event CheckStateChangedEventHandler CheckStateChanged;

        private void OnCheckStateChanged(int index)
        {
            CheckStateChanged?.Invoke(this, new CheckeBoxEventArgs(index));
        }
        #endregion

        #endregion
    }
}
