using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingProject;
using BankingLibrary;

namespace UnitTestBankingSolution {
	[TestClass]
	public class UnitTest1 {
		//Test for no money in or out, should return 0
		[TestMethod]
		public void TestZeroTransaction() {
			Account account = new Account("");
			var intitialbalance = account.CheckBalance();
			var deposit = account.Deposit(0);
			var withdraw = account.Withdraw(0);
			var result = account.CheckBalance();
			Assert.AreEqual(0, result, $"A deposit of {deposit} and a withdraw of {withdraw} resulted in the balance changing from {intitialbalance} to {result}");
		}
		//Test for max deposit, no money out, should return int.MaxValue
		[TestMethod]
		public void TestMaxDepositZeroWithdraw() {
			Account account = new Account("");
			var intitialbalance = account.CheckBalance();
			var deposit = account.Deposit(int.MaxValue);
			var withdraw = account.Withdraw(0);
			var result = account.CheckBalance();
			Assert.AreEqual(int.MaxValue, result, $"A deposit of {deposit} and a withdraw of {withdraw} resulted in the balance changing from {intitialbalance} to {result}");
		}
		//Test for no deposit, max withdraw, should return 0
		[TestMethod]
		public void TestZeroDepositMaxWithdraw() {
			Account account = new Account("");
			var intitialbalance = account.CheckBalance();
			var deposit = account.Deposit(0);
			var withdraw = account.Withdraw(int.MaxValue);
			var result = account.CheckBalance();
			Assert.AreEqual(0, result, $"A deposit of {deposit} and a withdraw of {withdraw} resulted in the balance changing from {intitialbalance} to {result}");
		}
		//Test for max deposit, max withdraw, should return 0
		[TestMethod]
		public void TestMaxDepositMaxWithdraw() {
			Account account = new Account("");
			var intitialbalance = account.CheckBalance();
			var deposit = account.Deposit(int.MaxValue);
			var withdraw = account.Withdraw(int.MaxValue);
			var result = account.CheckBalance();
			Assert.AreEqual(0, result, $"A deposit of {deposit} and a withdraw of {withdraw} resulted in the balance changing from {intitialbalance} to {result}");
		}
	}
}
