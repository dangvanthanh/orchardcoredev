import fs from "fs";
import path from "path";
import esbuild from "esbuild";
import { argv } from "node:process";
import { sassPlugin } from "esbuild-sass-plugin";
import postcss from "postcss";
import autoprefixer from "autoprefixer";
import tailwindcss from "tailwindcss";
import glob from "glob-all";

const production =
  "development" !== (argv[2].replace("--", "") || process.env.NODE_ENV);

console.log(`⚡ ${production ? "Production" : "Development"} build ⚡`);

function readEntryPoints(filePath) {
  const content = fs.readFileSync(filePath, "utf8");
  return JSON.parse(content);
}

function build(entryPointsObject) {
  esbuild
    .build({
      entryPoints: entryPointsObject,
      bundle: true,
      outdir: "./",
      format: "esm",
      sourcemap: !production,
      minify: production,
      plugins: [
        sassPlugin({
          async transform(source) {
            const { css } = await postcss([tailwindcss, autoprefixer]).process(
              source,
              {
                from: undefined,
              }
            );
            return css;
          },
        }),
      ],
    })
    .then(() => console.log("⚡ Build complete! ⚡"))
    .catch(() => process.exit(1));
}

const srcPath = "./src";

// const topLevelFolders = fs
//   .readdirSync(srcPath, { withFileTypes: true })
//   .filter((dirent) => dirent.isDirectory())
//   .map((dirent) => dirent.name);

const topLevelFolders = glob
  .sync(`${srcPath}/*`, {
    onlyDirectories: true,
  })
  .map((folderPath) => path.basename(folderPath));

// const subFolders = topLevelFolders.flatMap((folder) => {
//   const folderPath = path.join(srcPath, folder);
//   return fs
//     .readdirSync(folderPath, { withFileTypes: true })
//     .filter((dirent) => dirent.isDirectory())
//     .map((dirent) => path.join(folder, dirent.name));
// });

const subFolders = topLevelFolders
  .flatMap((folder) => {
    return glob.sync(`${srcPath}/${folder}/*`, {
      onlyDirectories: true,
    });
  })
  .map((folderPath) => path.relative(srcPath, folderPath));

const entryPointsConfig = subFolders.reduce((acc, folder) => {
  const assetsJsonPath = path.join(srcPath, folder, "Assets.json");
  if (fs.existsSync(assetsJsonPath)) {
    let assetConfigs = readEntryPoints(assetsJsonPath);

    assetConfigs = assetConfigs.map((config) => {
      config.input = `${srcPath}/${folder}/${config.input}`;
      config.output = `${srcPath}/${folder}/${config.output}`;
      return config;
    });

    acc = acc.concat(assetConfigs); // Concatenate the array of asset configurations
  }
  return acc;
}, []);

// Map the array of asset configurations to an object
const entryPointsObject = entryPointsConfig.reduce((acc, assetConfig) => {
  acc[assetConfig.output] = assetConfig.input;
  return acc;
}, {});

build(entryPointsObject);
