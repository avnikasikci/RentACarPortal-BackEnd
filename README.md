# RentACarPortal Web Api

It is a platform project where car rental companies can follow their vehicles.

**Api Modules**
- Car
- Report Modules
- Work List
- Car Detail

## [Demo website](https://budgetmanager.avnikasikci.com/)
# Project Structure

css/main.css file is created from main.scss file which is inside the scss folder. 
main.scss file is used to import the other scss files. CSS codes of the pages are included in the scss/pages folder. CSS codes of the header and footer are included in the scss/global folder. CSS codes of the common components of the website are included in the scss/components.

LiquidJS is used as a template engine.
Files of the template are in the views folder.
Files in the views/pages folder are extended from the file called views/master.liquid. HTML codes of the common components of the website are included in the views/components which is in the views folder.

## Installation

```bash
git clone https://github.com/hey-fk/personal-blog-template
cd personal-blog-template
npm install or yarn install
```

## Start the server

```bash
gulp
```

Now enter [`localhost:3000`](http://localhost:3000) in the address bar of your browser.

## Dist Folder

```bash
gulp dist
```

Production files will be prepared in /dist folder.

## Deploy Vercel

Build Command
```bash
gulp dist
```

Output Directory
```bash
dist
```

## Contributing

Did you found a bug or got an idea for a new feature? Feel free to use the [issue tracker](https://github.com/hey-fk/personal-blog-template/issues) to let me know. Or make directly a [pull request](https://github.com/hey-fk/personal-blog-template/pulls).

## Credits

Design: [Portfolio UI - Web & Mobile by Tinjo Thomas](https://www.figma.com/community/file/882879599442878081)

## License

This template is released under the MIT License.
