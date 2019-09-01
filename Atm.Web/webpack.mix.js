const mix = require('laravel-mix');

mix.js('Scripts/app.js', 'wwwroot/dist')
    .sass('Styles/app.scss', 'wwwroot/dist');
