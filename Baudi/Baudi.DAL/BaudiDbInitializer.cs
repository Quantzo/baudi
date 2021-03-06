﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Baudi.DAL.Models;

namespace Baudi.DAL
{
    public class BaudiDbInitializer : CreateDatabaseIfNotExists<BaudiDbContext>
    {
        protected override void Seed(BaudiDbContext context)
        {
            #region Buildings

            var buildings = new List<Building>
            {
                new Building
                {
                    NotificationTargetID = 1,
                    City = "Gliwice",
                    HouseNumber = "8",
                    Street = "Jana Pawla II"
                },
                new Building
                {
                    NotificationTargetID = 2,
                    City = "Gliwice",
                    HouseNumber = "16",
                    Street = "Zwirka i Muchomorka"
                }
            };

            #endregion

            #region Locals

            var locals1 = new List<Local>
            {
                new Local
                {
                    NotificationTargetID = 3,
                    Area = 60,
                    LocalNumber = "1",
                    RentValue = 300,
                    NumberOfRooms = 2,
                    Building = buildings[0]
                },
                new Local
                {
                    NotificationTargetID = 4,
                    Area = 60,
                    LocalNumber = "2",
                    RentValue = 300,
                    NumberOfRooms = 2,
                    Building = buildings[0]
                }
            };
            var locals2 = new List<Local>
            {
                new Local
                {
                    NotificationTargetID = 5,
                    Area = 80,
                    LocalNumber = "1",
                    RentValue = 400,
                    NumberOfRooms = 3,
                    Building = buildings[1]
                },
                new Local
                {
                    NotificationTargetID = 6,
                    Area = 80,
                    LocalNumber = "2",
                    RentValue = 400,
                    NumberOfRooms = 3,
                    Building = buildings[1]
                }
            };
            buildings[0].Locals = locals1;
            buildings[1].Locals = locals2;

            #endregion

            #region Notifications

            #region Notifications for Buildings

            var notifactions1 = new List<Notification>
            {
                new Notification
                {
                    NotificationID = 1,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Śmieci poszly",
                    Status = NotificationStatus.Completed,
                    NotificationTarget = buildings[0]
                },
                new Notification
                {
                    NotificationID = 2,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Pynk tynk",
                    Status = NotificationStatus.InProgress,
                    NotificationTarget = buildings[0]
                }
            };
            var notifactions2 = new List<Notification>
            {
                new Notification
                {
                    NotificationID = 3,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Poszło oświetlenie",
                    Status = NotificationStatus.Completed,
                    NotificationTarget = buildings[1]
                },
                new Notification
                {
                    NotificationID = 4,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Ukradziono substancję rdzeniową",
                    Status = NotificationStatus.Completed,
                    NotificationTarget = buildings[1]
                }
            };

            buildings[0].Notifactions = notifactions1;
            buildings[1].Notifactions = notifactions2;

            #endregion

            #region Notifications for Locals

            var notifactions3 = new List<Notification>
            {
                new Notification
                {
                    NotificationID = 5,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Kran",
                    Status = NotificationStatus.Completed,
                    NotificationTarget = buildings[0].Locals[0]
                },
                new Notification
                {
                    NotificationID = 6,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Description = "Zlew",
                    Status = NotificationStatus.Completed,
                    NotificationTarget = buildings[0].Locals[0]
                }
            };
            buildings[0].Locals[0].Notifactions = notifactions3;

            #endregion

            #region All notifications

            var allNotifications = new List<Notification>();
            allNotifications.AddRange(notifactions1);
            allNotifications.AddRange(notifactions2);
            allNotifications.AddRange(notifactions3);

            #endregion

            #endregion

            #region Cyclic Orders

            var cyclicOrders = new List<CyclicOrder>
            {
                new CyclicOrder
                {
                    ExpenseTargetID = 1,
                    Cost = 400,
                    Frequency = "tydzien",
                    Description = "Zleceni stałe 1",
                    LastRealizationDate = DateTime.ParseExact("26/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Building = buildings[0]
                },
                new CyclicOrder
                {
                    ExpenseTargetID = 2,
                    Cost = 200,
                    Frequency = "tydzien",
                    Description = "Zleceni stałe 2",
                    LastRealizationDate = DateTime.ParseExact("27/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Building = buildings[0]
                },
                new CyclicOrder
                {
                    ExpenseTargetID = 3,
                    Cost = 400,
                    Frequency = "tydzien",
                    Description = "Zleceni stałe 3",
                    LastRealizationDate = DateTime.ParseExact("28/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Building = buildings[0]
                }
            };
            buildings[0].CyclicOrders = cyclicOrders;

            #endregion

            #region Ownerships

            var ownerships1 = new List<Ownership>
            {
                new Ownership
                {
                    OwnershipID = 1,
                    PurchaseDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SaleDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Local = buildings[0].Locals[0]
                },
                new Ownership
                {
                    OwnershipID = 2,
                    PurchaseDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SaleDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Local = buildings[0].Locals[0]
                }
            };


            var ownerships2 = new List<Ownership>
            {
                new Ownership
                {
                    OwnershipID = 3,
                    PurchaseDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SaleDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Local = buildings[1].Locals[0]
                },
                new Ownership
                {
                    OwnershipID = 4,
                    PurchaseDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    SaleDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Local = buildings[1].Locals[0]
                }
            };

            buildings[0].Locals[0].Ownerships = ownerships1;
            buildings[1].Locals[0].Ownerships = ownerships2;

            #endregion

            #region Specializations

            var spec1 = new Specialization
            {
                SpecializationID = 1,
                Name = "Szklorzohydrualik"
            };
            var spec2 = new Specialization
            {
                SpecializationID = 2,
                Name = "Śmieciarz"
            };
            var spec3 = new Specialization
            {
                SpecializationID = 3,
                Name = "Wszystkmistrz"
            };

            #endregion

            #region Order Types

            var orderType1 = new OrderType
            {
                OrderTypeID = 1,
                Name = "Kran&Zlewy inc",
                Specializations = new List<Specialization> { spec1, spec3 }
            };
            var orderType2 = new OrderType
            {
                OrderTypeID = 2,
                Name = "zbite okno(tak mocno)",
                Specializations = new List<Specialization> { spec1, spec3 }
            };
            var orderType3 = new OrderType
            {
                OrderTypeID = 3,
                Name = "śmieciory",
                Specializations = new List<Specialization> { spec2, spec3 }
            };

            spec1.OrderTypes = new List<OrderType> { orderType1, orderType2 };
            spec2.OrderTypes = new List<OrderType> { orderType3 };
            spec3.OrderTypes = new List<OrderType> { orderType1, orderType2, orderType3 };

            #endregion

            #region Orders

            #region Orders for Buildings notifications

            var orders1 = new List<Order>
            {
                new Order
                {
                    ExpenseTargetID = 4,
                    Cost = 20,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 1",
                    OrderType = spec2.OrderTypes[0],
                    Notification = buildings[0].Notifactions[0]
                },
                new Order
                {
                    ExpenseTargetID = 5,
                    Cost = 500,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 2",
                    OrderType = spec2.OrderTypes[0],
                    Notification = buildings[0].Notifactions[0]
                }
            };

            var orders2 = new List<Order>
            {
                new Order
                {
                    ExpenseTargetID = 6,
                    Cost = 20,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 3",
                    OrderType = spec2.OrderTypes[0],
                    Notification = buildings[1].Notifactions[0]
                },
                new Order
                {
                    ExpenseTargetID = 7,
                    Cost = 500,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 4",
                    OrderType = spec2.OrderTypes[0],
                    Notification = buildings[1].Notifactions[0]
                }
            };

            buildings[0].Notifactions[0].Orders = orders1;
            buildings[1].Notifactions[0].Orders = orders2;

            #endregion

            #region Orders for Locals notifications

            var orders3 = new List<Order>
            {
                new Order
                {
                    ExpenseTargetID = 8,
                    Cost = 20,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 5",
                    OrderType = spec1.OrderTypes[0],
                    Notification = buildings[0].Locals[0].Notifactions[0]
                },
                new Order
                {
                    ExpenseTargetID = 9,
                    Cost = 500,
                    LastChanged = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    FilingDate = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Status = OrderStatus.Completed,
                    Description = "Zlecenie 6",
                    OrderType = spec3.OrderTypes[0],
                    Notification = buildings[0].Locals[0].Notifactions[0]
                }
            };
            buildings[0].Locals[0].Notifactions[0].Orders = orders3;

            #endregion

            #endregion

            #region Rents

            var rents1 = new List<Rent>
            {
                new Rent
                {
                    PaymentID = 1,
                    Cost = 22,
                    Date = DateTime.ParseExact("21/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    Ownership = buildings[0].Locals[0].Ownerships[0]
                },
                new Rent
                {
                    PaymentID = 2,
                    Cost = 22,
                    Date = DateTime.ParseExact("22/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    Ownership = buildings[0].Locals[0].Ownerships[0]
                },
                new Rent
                {
                    PaymentID = 3,
                    Cost = 22,
                    Date = DateTime.ParseExact("23/08/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = false,
                    Ownership = buildings[0].Locals[0].Ownerships[0]
                }
            }
                ;
            var rents2 = new List<Rent>
            {
                new Rent
                {
                    PaymentID = 4,
                    Cost = 22,
                    Date = DateTime.ParseExact("22/09/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    Ownership = buildings[0].Locals[0].Ownerships[1]
                },
                new Rent
                {
                    PaymentID = 5,
                    Cost = 22,
                    Date = DateTime.ParseExact("24/09/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    Ownership = buildings[0].Locals[0].Ownerships[1]
                },
                new Rent
                {
                    PaymentID = 6,
                    Cost = 22,
                    Date = DateTime.ParseExact("24/02/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = false,
                    Ownership = buildings[0].Locals[0].Ownerships[1]
                }
            }
                ;

            var rents3 = new List<Rent>
            {
                new Rent
                {
                    PaymentID = 7,
                    Cost = 22,
                    Date = DateTime.ParseExact("24/02/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    Ownership = buildings[1].Locals[0].Ownerships[0]
                }
            };
            buildings[0].Locals[0].Ownerships[0].Rents = rents1;
            buildings[0].Locals[0].Ownerships[1].Rents = rents2;
            buildings[1].Locals[0].Ownerships[0].Rents = rents3;

            #endregion

            #region Expenses

            #region Expeses for Cyclic Orders

            var expenseCyclic = new List<Expense>
            {
                new Expense
                {
                    PaymentID = 8,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("21/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    ExpenseTarget = buildings[0].CyclicOrders[0]
                },
                new Expense
                {
                    PaymentID = 9,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("23/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    ExpenseTarget = buildings[0].CyclicOrders[0]
                }
            };

            buildings[0].CyclicOrders[0].Expenses = expenseCyclic;

            #endregion

            #region Expeses for Orders

            var expenseOrder = new List<Expense>
            {
                new Expense
                {
                    PaymentID = 10,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("23/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,
                    ExpenseTarget = buildings[0].Notifactions[0].Orders[0]
                },
                new Expense
                {
                    PaymentID = 11,
                    Cost = 554.4,
                    Date = DateTime.ParseExact("23/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = false,
                    ExpenseTarget = buildings[0].Notifactions[0].Orders[0]
                }
            };

            buildings[0].Notifactions[0].Orders[0].Expenses = expenseOrder;

            #endregion

            #region  Salary for Employes

            #region Menager salary

            var salary1 = new List<Salary>
            {
                new Salary
                {
                    PaymentID = 12,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("21/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true,

                },
                new Salary
                {
                    PaymentID = 13,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("22/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true
                }
            };

            #endregion

            #region Dispatcher salary

            var salary2 = new List<Salary>
            {
                new Salary
                {
                    PaymentID = 14,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("23/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true
                },
                new Salary
                {
                    PaymentID = 15,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("24/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true
                }
            };

            #endregion

            #region Admin salary

            var salary3 = new List<Salary>
            {
                new Salary
                {
                    PaymentID = 16,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("25/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true
                },
                new Salary
                {
                    PaymentID = 17,
                    Cost = 55.4,
                    Date = DateTime.ParseExact("26/12/2015", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    Paid = true
                }
            };

            #endregion

            #endregion

            #region All expenses

            var allExpenses = new List<Expense>();
            allExpenses.AddRange(expenseCyclic);
            allExpenses.AddRange(expenseOrder);
            var allSalaries = new List<Salary>();
            allSalaries.AddRange(salary1);
            allSalaries.AddRange(salary2);
            allSalaries.AddRange(salary3);

            #endregion

            #endregion

            #region Employees

            #region Menagers

            var menager = new Menager
            {
                OwnerID = 1,
                BankAccountNumber = "212",
                Salary = 44,
                City = "MenagerCity",
                Street = "nowa",
                HouseNumber = "11",
                LocalNumber = "1",
                Name = "Menager",
                Surname = "Menager",
                PESEL = "1111",
                Telephone = "12344",
                Salaries = salary1,
                MenagerExpenses = allExpenses,
                MenagerSalaries = allSalaries,
                Username = "Men",
                Password = SecurityHelper.ComputeHash("12345"),
                PasswordSalt = "",

            };

            #region Binding for Cyclic orders

            buildings[0].CyclicOrders.ForEach(cO => cO.Menager = menager);

            #endregion

            #region Binding for orders

            buildings[0].Notifactions[0].Orders.ForEach(cO => cO.Menager = menager);
            buildings[1].Notifactions[0].Orders.ForEach(cO => cO.Menager = menager);
            buildings[0].Locals[0].Notifactions[0].Orders.ForEach(cO => cO.Menager = menager);

            #endregion

            #endregion

            #region Dispatchers

            var dispatcher = new Dispatcher
            {
                OwnerID = 2,
                BankAccountNumber = "212",
                Salary = 44,
                City = "DispatcherCity",
                Street = "nowa",
                HouseNumber = "11",
                LocalNumber = "1",
                Name = "Dispatcher",
                Surname = "Dispatcher",
                PESEL = "1111",
                Telephone = "12344",
                Salaries = salary2,
                DispatcherNotifications = allNotifications,
                                Username = "Disp",
                Password = SecurityHelper.ComputeHash("12345"),
                PasswordSalt = "",
            };
            buildings[0].Notifactions.ForEach(n => n.Dispatcher = dispatcher);
            buildings[1].Notifactions.ForEach(n => n.Dispatcher = dispatcher);
            buildings[0].Locals[0].Notifactions.ForEach(n => n.Dispatcher = dispatcher);

            #endregion

            #region Admins

            var admin = new Administrator
            {
                OwnerID = 3,
                BankAccountNumber = "212",
                Salary = 44,
                City = "AdminCity",
                Street = "nowa",
                HouseNumber = "11",
                LocalNumber = "1",
                Name = "Admin",
                Surname = "Admin",
                PESEL = "1111",
                Telephone = "12344",
                Salaries = salary3,
                Username = "Admin",
                Password = SecurityHelper.ComputeHash("12345"),
                PasswordSalt = "",
                Ownerships = new List<Ownership> { buildings[1].Locals[0].Ownerships[0] }
            };

            #endregion

            #endregion

            #region Companies

            var company1 = new Company
            {
                Name = "Firma 1",
                CompanyID = 1,
                City = "Gliwice",
                HouseNumber = "7",
                Street = "Zwirtka",
                LocalNumber = "",
                TelephoneNumber = "234251356",
                Owner = "Jan Poniedzialek",
                Specializations = new List<Specialization> { spec1, spec2 },
                CyclicOrders = new List<CyclicOrder> { buildings[0].CyclicOrders[0], buildings[0].CyclicOrders[1] },
                Orders = buildings[1].Notifactions[0].Orders
            };

            var company2 = new Company
            {
                Name = "Firma 2",
                CompanyID = 2,
                City = "Zabrze",
                HouseNumber = "5",
                Street = "Srodkowa",
                LocalNumber = "4",
                TelephoneNumber = "342364325",
                Owner = "Aleksander Palmowski",
                Specializations = new List<Specialization> { spec1, spec2 },
                CyclicOrders = new List<CyclicOrder>(),
                Orders = buildings[0].Notifactions[0].Orders
            };

            var company3 = new Company
            {
                Name = "Firma 3",
                CompanyID = 3,
                City = "Gliwice",
                HouseNumber = "3",
                Street = "Stulecia",
                LocalNumber = "",
                TelephoneNumber = "753456534",
                Owner = "Franciszek Wypiek",
                Specializations = new List<Specialization> { spec3 },
                CyclicOrders = new List<CyclicOrder> { buildings[0].CyclicOrders[2] },
                Orders = buildings[0].Locals[0].Notifactions[0].Orders
            };

            #region Binding for Cyclic orders

            buildings[0].CyclicOrders[0].Company = company1;
            buildings[0].CyclicOrders[1].Company = company1;
            buildings[0].CyclicOrders[2].Company = company3;

            #endregion

            #region Binding for Orders

            buildings[0].Notifactions[0].Orders.ForEach(o => o.Company = company2);
            buildings[1].Notifactions[0].Orders.ForEach(o => o.Company = company1);
            buildings[0].Locals[0].Notifactions[0].Orders.ForEach(o => o.Company = company3);

            #endregion

            #endregion

            #region Owners

            var person = new Person
            {
                OwnerID = 4,
                Name = "Jacek",
                Surname = "Poniedzialek",
                PESEL = "84928475839",
                City = "Gliwice",
                HouseNumber = "4",
                Street = "Bukowa",
                LocalNumber = "1",
                Telephone = "678976546",
                Notifications = buildings[0].Locals[0].Notifactions,
                Ownerships = buildings[0].Locals[0].Ownerships
            };

            var notificationsForOwniningCompany = new List<Notification>();
            notificationsForOwniningCompany.AddRange(buildings[0].Notifactions);
            notificationsForOwniningCompany.AddRange(buildings[1].Notifactions);
            var owningCompany = new OwningCompany
            {
                OwnerID = 5,
                Name = "Lunar LC",
                NIP = "85938573948",
                City = "Gliwice",
                HouseNumber = "2",
                Street = "Kalinowa",
                LocalNumber = "4",
                Telephone = "357468645",
                Notifications = notificationsForOwniningCompany,
                Ownerships = new List<Ownership> { buildings[1].Locals[0].Ownerships[1] }
            };

            #region Binding for Notifications

            buildings[0].Notifactions.ForEach(n => n.Owner = owningCompany);
            buildings[1].Notifactions.ForEach(n => n.Owner = owningCompany);
            buildings[0].Locals[0].Notifactions.ForEach(n => n.Owner = person);

            #endregion

            #region Binding for Ownerships

            buildings[0].Locals[0].Ownerships.ForEach(o => o.Owner = person);
            buildings[1].Locals[0].Ownerships[0].Owner = admin;
            buildings[1].Locals[0].Ownerships[1].Owner = owningCompany;

            #endregion

            #endregion


            
            foreach (var b in buildings)
            {
                context.Buildings.Add(b);
            }
            context.Employees.Add(admin);
            context.OwningCompanies.Add(owningCompany);


            base.Seed(context);
            context.SaveChanges();
        }
    }

    internal static class SecurityHelper
    {
        public static string ComputeHash(string password)
        {
            string computedHash;
            using (var hash = new SHA512Managed())
            {
                computedHash =
                    Convert.ToBase64String(hash.ComputeHash((Encoding.UTF8.GetBytes(password))));
            }
            return computedHash;
        }
    }
}