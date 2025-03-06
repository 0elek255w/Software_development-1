<template>
  <div class="cart">
    <h2>Корзина</h2>
    <div v-if="cartStore.cartItems.length">
      <div v-for="item in cartStore.cartItems" :key="item.id" class="cart-item">
        <img :src="item.image" :alt="item.name" />
        <div>
          <h3>{{ item.name }}</h3>
          <p>{{ item.price }} ₽</p>
          <div class="quantity-controls">
            <button @click="decreaseQuantity(item.id)" :disabled="item.quantity <= 1">-</button>
            <span>{{ item.quantity }}</span>
            <button @click="increaseQuantity(item.id)">+</button>
          </div>
        </div>
        <button @click="removeFromCart(item.id)">Удалить</button>
      </div>
      <h3>Итого: {{ totalPrice }} ₽</h3>
      <button @click="cartStore.clearCart()">Очистить корзину</button>
    </div>
    <p v-else>Корзина пуста</p>
  </div>
</template>


<script>

import { useCartStore } from "@/stores/cart";
import { computed } from "vue";

export default {
  setup() {
    const cartStore = useCartStore();

    const totalPrice = computed(() =>
      cartStore.cartItems.reduce((sum, item) => sum + item.price * item.quantity, 0)
    );
    
    // Увеличение количества товара
    const increaseQuantity = (id) => {
      cartStore.increaseQuantity(id);
    };


    const removeFromCart = (id) => {
      cartStore.removeFromCart(id);
    };

    
    // Уменьшение количества товара
    const decreaseQuantity = (id) => {
      cartStore.decreaseQuantity(id);
    };

    return { cartStore, totalPrice, removeFromCart, increaseQuantity, decreaseQuantity };
  },
};
</script>

<style scoped>
.cart-item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid #ddd;
  padding: 10px;
}
img {
  width: 50px;
  height: 50px;
  border-radius: 5px;
}
button {
  background: #ff5733;
  color: white;
  padding: 8px;
  border: none;
  cursor: pointer;
}

.cart-item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid #ddd;
  padding: 10px;
}

img {
  width: 50px;
  height: 50px;
  border-radius: 5px;
}

button {
  background: #ff5733;
  color: white;
  padding: 8px;
  border: none;
  cursor: pointer;
}

button:hover {
  background: #e04f2e;
}

button:disabled {
  background: #ccc;
  cursor: not-allowed;
}

.quantity-controls {
  display: flex;
  align-items: center;
  gap: 10px;
}

span {
  font-size: 1.2rem;
  font-weight: bold;
}

</style>