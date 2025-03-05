<template>
  <div class="cart">
    <h1>Ваша корзина</h1>
    <p>Здесь будет список выбранных товаров.</p>
    <router-link to="/">Вернуться на главную</router-link> <!-- Кнопка для возврата на главную -->
  </div>
</template>

<script>
export default {
  name: 'Cart',
};
</script>

<style scoped>
.cart {
  text-align: center;
  margin-top: 50px;
}
</style>
