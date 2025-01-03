# oEconomy

Welcome to the Economy Plugin for ObsidianMC! This plugin provides essential economy management features for your server, allowing admins to control player balances and enabling players to interact with their in-game currency.

---

## Features

### Admin Commands
- **`/eco give <player> <amount>`**  
  *Gives a player money out of thin air.*

- **`/eco take <player> <amount>`**  
  *Takes money from a player.*

- **`/eco set <player> <amount>`**  
  *Sets a player's balance to a specified value.*

### Player Commands
- **`/balance` or `/bal`**  
  *Displays your current balance.*

- **`/balance <player>` or `/bal <player>`**  
  *Displays another player's balance.*

- **`/pay <player> <amount>`**  
  *Transfers money to another player.*

- **`/baltop`**  
  *Lists the top 10 players with the highest balances.*

---

## Installation
1. Download the plugin .obby file.
2. Place the file in the `plugins` directory of your ObsidianMC server.
3. Restart your server.

### Required Dependency
This plugin requires **ObsidianVault** to function. Download it here: [ObsidianVault](https://harbr.dev/plugin/obsidian-vault).

---

## Configuration
No additional configuration is required. The plugin uses the default Vault API for managing balances. Ensure Vault is installed and properly set up on your server.

---

## Permissions
The plugin uses a permission system to control access to commands:

- **Admin Commands:** Require the `eco.admin` permission.
- **Player Commands:** Available to all players by default, except `/eco` commands.

---

## Command Details

### Admin Commands

#### `/eco give <player> <amount>`
- **Description:** Gives the specified player an amount of money.
- **Permission Required:** `eco.admin`
- **Example:** `/eco give Steve 100`

#### `/eco take <player> <amount>`
- **Description:** Takes money from a player.
- **Permission Required:** `eco.admin`
- **Example:** `/eco take Alex 50`

#### `/eco set <player> <amount>`
- **Description:** Sets a player's balance to a specific value.
- **Permission Required:** `eco.admin`
- **Example:** `/eco set Notch 1000`

### Player Commands

#### `/balance` or `/bal`
- **Description:** Displays your current balance.
- **Permission Required:** None
- **Example:** `/balance`

#### `/balance <player>` or `/bal <player>`
- **Description:** Displays another player's balance.
- **Permission Required:** None
- **Example:** `/bal Steve`

#### `/pay <player> <amount>`
- **Description:** Transfers money to another player.
- **Permission Required:** None
- **Example:** `/pay Alex 200`

#### `/baltop`
- **Description:** Displays the top 10 players with the highest balances.
- **Permission Required:** None
- **Example:** `/baltop`

---

## Future Planned Features
- **Tax Command:** Admins will be able to set a tax rate on every payment made between players.
- **Physical Coins:** Players will have the ability to withdraw and deposit physical coins (items). Taxes will not apply to transactions involving physical coins.

---

## Contributing
Feel free to contribute to this plugin by submitting pull requests or reporting issues on the GitHub repository.

---

## License
This plugin is open-source and distributed under the MIT License.

---

Enjoy managing your server economy!

