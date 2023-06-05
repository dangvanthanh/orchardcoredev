import Alpine, { Alpine as AlpineType } from "alpinejs";

declare global {
  interface Window {
    Alpine: AlpineType;
  }
}

window.Alpine = Alpine;

Alpine.data("dropdown", () => ({
  open: false,
  toggle() {
    this.open = !this.open;
  },
}));

Alpine.store("darkMode", {
  on: false,
  toggle() {
    this.on = !this.on;
  },
});

Alpine.start();
