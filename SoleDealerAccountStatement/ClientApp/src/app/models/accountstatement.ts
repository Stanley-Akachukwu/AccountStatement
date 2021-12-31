
export interface AccountStatement {
  id: number;
  accountNumber: string;
  transactionType: string;
  sourceAccount: string;
  destinationAccount: string;
  amount: number;
  transactionDate: Date;
  transactionDetails: string;
}
