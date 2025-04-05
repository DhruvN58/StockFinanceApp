import sqlite3

# # ...existing code...

# # Connect to the SQLite database
connection = sqlite3.connect('FinanceAppDB.db')  # Replace 'finance.db' with your database file name
cursor = connection.cursor()

# # Prompt the user for the condition to delete a stock
# delete_id = int(input("Enter the stock ID to delete: "))

# # Correctly use the cursor object to execute the DELETE query
# cursor.execute('''
# DELETE FROM stocks WHERE id = ?
# ''', (delete_id,))

# # Commit the changes and close the connection
# connection.commit()
# connection.close()

# print(f"Record with ID {delete_id} deleted successfully.")

# ...existing code...



# ...existing code...

# Prompt the user for stock details
Id = int(input("Enter stock ID: "))
Symbol = input("Enter stock symbol: ")
Companyname = input("Enter stock name: ")
Purchase = float(input("Enter stock price: "))
LastDiv = float(input("Enter stock last dividend: "))
Industry = input("Enter stock industry: ")
MarketCap = float(input("Enter stock market cap: "))

# Insert a new stock record using user input
cursor.execute('''
INSERT INTO stocks (id, symbol, company_name, purchase_price, last_dividend, industry, market_cap)
VALUES (?, ?, ?, ?, ?, ?, ?)
''', (Id, Symbol, Companyname, Purchase, LastDiv, Industry, MarketCap))

# ...existing code...


