using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quicksort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] getList()
        {
            List<int> lst = new List<int>();

            foreach (string s in txtInput.Text.Split(' ')) //entries are divided by a space
                lst.Add(Convert.ToInt32(s));

            return lst.ToArray();
        }

        private int[] quickSort(int[] elements, int left, int right)
        {
            int L = left, R = right;
            int pivot = elements[(L + R) / 2];
            int[] returnVal = elements;

            while (L <= R)
            {
                while (returnVal[L] < pivot)
                    L++;

                while (returnVal[R] > pivot)
                    R--;

                if (L <= R) //swap L and R
                {
                    int tmp = returnVal[L];
                    returnVal[L] = returnVal[R];
                    returnVal[R] = tmp;

                    L++;
                    R--;
                }
            }


            if (left < R)
                returnVal = quickSort(elements, left, L);
            if (L < right)
                returnVal = quickSort(elements, R, right);

            return returnVal;
        }

        private int[] quickSortWiki(int[] elements, int left, int right)
        {
            if (left < right)
            {
                int p = partitionWiki(elements, left, right);
                quickSortWiki(elements, left, p);
                quickSortWiki(elements, p + 1, right);
            }
            return elements;
        }

        private int partitionWiki(int[] elements, int left, int right)
        {
            int pivot = elements[left];
            int i = left;
            int j = right;

            while (1 == 1)
            {
                while (elements[i] < pivot)
                {
                    i = i + 1;
                }

                while (elements[j] > pivot)
                {
                    j = j - 1;
                }

                if (i >= j)
                {
                    return j;
                }

                int tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;
            }

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int[] unsorted = getList();

            //  int[] sorted = quickSort(unsorted, 0, unsorted.Length - 1);

            int[] sorted = quickSortWiki(unsorted, 0, unsorted.Length - 1);

            //after sorting write to lbl
            foreach (int i in sorted)
                lblOutput.Text += i.ToString() + " ";
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            //prevents typing keys other than space or numbers
            string output = "";
            foreach (char c in txtInput.Text)
                if (char.IsDigit(c) || c == ' ')
                    output += c;
            txtInput.Text = output;

            txtInput.SelectionStart = txtInput.Text.Length; //moves cursor to end Without this cursor moves to beginning
        }
    }
}
