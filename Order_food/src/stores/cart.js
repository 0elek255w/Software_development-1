import { defineStore } from "pinia";

export const useCartStore = defineStore("cart", {
  state: () => ({
    cartItems: JSON.parse(localStorage.getItem("cart")) || [],
  }),

  actions: {
    addToCart(product) {
      const item = this.cartItems.find((i) => i.id === product.id);
      if (item) {
        item.quantity += 1;
      } else {
        this.cartItems.push({ ...product, quantity: 1 });
      }
      this.saveCart();
    },

    removeFromCart(productId) {
      this.cartItems = this.cartItems.filter((item) => item.id !== productId);
      this.saveCart();
    },

    clearCart() {
      this.cartItems = [];
      this.saveCart();
    },

    increaseQuantity(productId) {
      const item = this.cartItems.find((i) => i.id === productId);
      if (item) {
        item.quantity += 1;
      }
      this.saveCart();
    },

    decreaseQuantity(productId) {
      const item = this.cartItems.find((i) => i.id === productId);
      if (item && item.quantity > 1) {
        item.quantity -= 1;
      }
      this.saveCart();
    },

    saveCart() {
      localStorage.setItem("cart", JSON.stringify(this.cartItems));
    },
  },
});
