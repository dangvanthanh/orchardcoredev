/** @type {import('postcss-load-config').Config} */

const config = {
  plugins: [
    require("postcss-import"),
    require("tailwindcss"),
    require("autoprefixer"),
  ],
};

module.exports = config;
