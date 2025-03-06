<template>
  <div class="menu">
    <div v-for="product in products" :key="product.id" class="card">
      <img :src="product.image" :alt="product.name" />
      <h3>{{ product.name }}</h3>
      <p>{{ product.price }} ₽</p>
      <button @click="addToCart(product)">Добавить в корзину</button>
    </div>
  </div>
</template>

<script>
import { useCartStore } from "@/stores/cart";
import { ref } from "vue";

export default {
  setup() {
    const cartStore = useCartStore();

    const products = ref([
      { id: 1, name: "Пицца Маргарита", price: 500, image: "маргарита.jpg" },
      { id: 2, name: "Пицца Пепперони", price: 600, image: "пепперони.jpg" },
    ]);

    const addToCart = (product) => {
      cartStore.addToCart(product);
    };

    return { products, addToCart };
  },
};
</script>

<style scoped>
.card {
  border: 1px solid #ddd;
  padding: 15px;
  text-align: center;
  margin-bottom: 10px;
}
button {
  background: #ff5733;
  color: white;
  padding: 10px;
  border: none;
  cursor: pointer;
}
</style>
