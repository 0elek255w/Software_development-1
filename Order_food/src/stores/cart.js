import { defineStore } from 'pinia';

export const useCartStore = defineStore('cart', {
  state: () => ({
    items: [], // Товары в корзине
  }),
  actions: {
    addToCart(item) {
      const existingItem = this.items.find(i => i.id === item.id);
      if (existingItem) {
        existingItem.quantity++;
      } else {
        this.items.push({ ...item, quantity: 1 });
      }
    },
    removeFromCart(item) {
      this.items = this.items.filter(i => i.id !== item.id);
    },
    clearCart() {
      this.items = [];
    },
  },
  getters: {
    cartTotal: (state) => {
      return state.items.reduce((total, item) => total + item.price * item.quantity, 0);
    },
  },
});
