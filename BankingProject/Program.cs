using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingLibrary;

namespace BankingProject {
	class Program {
		static void Main(string[] args) {
			new Program().Run();
		}
		void Run() {
			//The first Account made during this exercise, which is given the Name of "My Checking"
			Account checking = new Account("My Checking");
			//The second Account made, which is an Account, but needs to be called Savings, because it
			//will use items from the Savings class, in addition to items from the Account class. As such,
			//during the creation of "savings," two constructors are called, the one in Account that takes
			//a string to give an Account a Name, and the one in Savings, that takes the Name, and the IntRate
			//(the interest rate).
			//When "savings" is created, we gave it the Name "My Savings," and the IntRate of "0.10"
			Savings savings = new Savings("My Savings", 0.10);

			//Time to test the code, let's add some money to the two accounts, and take some away from checking.
			checking.Deposit(100.00);
			checking.Withdraw(20.00);
			savings.Deposit(350);

			//Show the Number for the checking account, the Name, and its balance.
			Console.WriteLine($"Account # {checking.GetNumber()}, Name: {checking.GetName()} has a balance of {checking.CheckBalance()}.");

			Console.WriteLine($"Account # {savings.GetNumber()}, Name: {savings.GetName()} has a balance of {savings.CheckBalance()}.");

			//Let's transfer some money from savings to checking.
			savings.Transfer(340, checking);

			//Time to add some interest to savings.
			savings.PayMonthlyInterest();

			//Creates a generic List, where each item is an "Account"
			List<Account> myAccounts = new List<Account>();
			myAccounts.Add(checking);
			myAccounts.Add(savings);

			//Goes through each item on the List, each being an Account, and calls the ToPrint method.
			foreach (var account in myAccounts) {
				Console.WriteLine(account.ToPrint());
			}

		}
	}
}
