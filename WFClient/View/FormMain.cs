﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFClient.Controller;

namespace WFClient.View
{
	enum MenuStatusBar
	{
		Shown,
		Hidden
	}

	public partial class FormMain : Form
	{
		private MenuStatusBar menuStatus = MenuStatusBar.Hidden;
		private int initialWidth;

		private ControllerFormMain controller;
		public FormMain()
		{
			InitializeComponent();

			initialWidth = this.tableLayoutPanelCardList.Width + 19;
			this.Width = initialWidth;

		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			controller = new ControllerFormMain(this);
			controller.UpdateLabel();

			GetCards();
		}

		private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			controller.CloseUp();
		}

		private void buttonShowHideMenu_Click(object sender, EventArgs e)
		{
			menuStatus = (MenuStatusBar)(((int)menuStatus + 1) % 2);

			this.Width = menuStatus == MenuStatusBar.Shown ? (int)Math.Round((double)(this.Width * 1.3)) : initialWidth;

			string title = "";

			switch (menuStatus)
			{
				case MenuStatusBar.Shown:
					title = "Hide\nMenu";
					break;
				case MenuStatusBar.Hidden:
					title = "Show\nMenu";
					break;
				default:
					break;
			}

			buttonShowHideMenu.Text = title;

		}
		private async void GetCards()
		{
			await controller.CardsGetCardsByUserId();
		}

		private void buttonTransfer_Click(object sender, EventArgs e)
		{
			new FormTransferController().Show();
			//TODO Make enw form for transfering
			//TODO Make transfering

		}

		private void buttonCreateNewCard_Click(object sender, EventArgs e)
		{
			// TODO Make new form for creating cards
			// TODO Make creating cards
		}

		private void buttonAddMoney_Click(object sender, EventArgs e)
		{
			// TODO Make new form for adding money
			// TODO Make adding money
		}
	}
}
