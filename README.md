# Ethereum Wallets
## Assignment
Create Blazor project using default template. Create page Wallets that should display a list of accounts in the form of a table (Id, Address, Balance). The table should be sorted by balance. Addresses are stored in the database (*wallets.sql*). Balances can be received from the ETH node.

## Conditions
1. Use Netehereum.Web3 for communication with the node. 
2. The page should load fast.

## Tools
- Nethereum package
- ETH testnet Sepolia (https://www.infura.io/)
- PostgreSQL

# Getting Started
1. Clone the repo.
2. Run docker container with the settings specified in the file *docker-compose.yml*.
3. Run script *wallets.sql* to create the table with data.
4. Start the application.
5. Navigate to the page **Wallets**.
