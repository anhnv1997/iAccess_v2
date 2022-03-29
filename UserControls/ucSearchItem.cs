using iAccess.Objects.Cards;
using iParking.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.UserControls
{
    public partial class ucSearchItem : UserControl
    {
        //ID
        //Display
        public ListItem SelectedItem { get; set; }
        public List<object> Datas { get; set; }

        public Type dataType { get; set; }
        public int MaxWidth { get; set; } = 0;
        public int MaxHeight { get; set; } = 0;

        private string selectedID = "";
        public string SelectedID { 
            get => selectedID;
            set {
                selectedID = value;
                
            }
        }

        public ucSearchItem(int maxHeight, int maxWidth, Type type, List<object> datas, string selectedID)
        {
            InitializeComponent();

            this.MaxWidth = maxWidth;
            this.MaxHeight = maxHeight;

            this.Width = maxWidth;
            this.Height = btnSelectedItem.Location.Y + btnSelectedItem.Height;

            Datas = datas;
            this.dataType = type;
            this.SelectedID = selectedID;

            if (type == typeof(Card))
            {
                List<Card> cardDatas = datas.Cast<Card>().ToList();
                foreach(Card card in cardDatas)
                {
                    ListViewItem item = new ListViewItem(card.Name);
                    item.SubItems.Add(card.CardCode);
                    item.SubItems.Add(card.CardNumber);
                    item.SubItems.Add(card.Description);
                    item.SubItems.Add(card.ID);
                    lvResult.Items.Add(item);
                }
                if (SelectedID != "")
                {
                    foreach (ListViewItem item in lvResult.Items)
                    {
                        string id = item.SubItems[4].Text;
                        if (id == this.SelectedID)
                        {
                            item.Selected = true;
                            item.Focused = true;
                            return;
                        }
                    }
                }
            }
        }

        private void btnSelectedItem_Click(object sender, EventArgs e)
        {
            if (this.Height > btnSelectedItem.Height)
            {
                this.Height = btnSelectedItem.Height;
            }
            else
            {
                this.Height = MaxHeight;
                
            }
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            if(this.dataType == typeof(Card))
            {
                List<Card> cardDatas = Datas.Cast<Card>().ToList();
                cardDatas = cardDatas.Where(card => 
                                               card.Name.ToLower().Contains(txtSearchItem.Text.ToLower())
                                            || card.CardCode.ToLower().Contains(txtSearchItem.Text.ToLower())
                                            || card.CardNumber.ToLower().Contains(txtSearchItem.Text.ToLower())
                                           ).ToList();
                lvResult.Items.Clear();
                foreach (Card card in cardDatas)
                {
                    ListViewItem item = new ListViewItem(card.Name);
                    item.SubItems.Add(card.CardCode);
                    item.SubItems.Add(card.CardNumber);
                    item.SubItems.Add(card.Description);
                    lvResult.Items.Add(item);
                }
            }
        }

        private void lvResult_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.lvResult.SelectedItems.Count == 0)
                return;
            if (this.dataType == typeof(Card))
            {
                string cardCode = e.Item.SubItems[1].Text;
                string cardNumber = e.Item.SubItems[2].Text;
                btnSelectedItem.Text = cardCode + " : " + cardNumber;
            }
            this.Height = btnSelectedItem.Height;
            this.SelectedID = e.Item.SubItems[4].Text;
        }
    }
}
