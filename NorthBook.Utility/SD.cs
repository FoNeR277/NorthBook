using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthBook.Utility
{
    public static class SD
    {
        public const string Role_User_Indi = "Individual" ;
        public const string Role_User_Comp = "Company";
        public const string Role_Admin = "Admin";
        public const string Role_Emploee = "Emploee";

        public const string StatusPending = "Pedning";
        public const string StatusShipped = "Shipped";
        public const string StatusApproved = "Approved";
        public const string StatusRefunded = "Refunded";
        public const string StatusInProcess = "InProcess";
        public const string StatusCancelled = "Cancelled";
        
        public const string PaymentStatusPending = "Pedning";
        public const string PaymentStatusRejected = "Rejected";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
    }
}
