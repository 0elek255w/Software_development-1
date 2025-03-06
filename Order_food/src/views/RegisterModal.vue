<template>
    <div class="modal-overlay" v-if="isVisible">
      <div class="modal-content">
        <h2>Регистрация</h2>
        <form @submit.prevent="handleSubmit">
          <div>
            <label for="username">Имя пользователя</label>
            <input type="text" id="username" v-model="username" required />
          </div>
          <div>
            <label for="email">Электронная почта</label>
            <input type="email" id="email" v-model="email" required />
          </div>
          <div>
            <label for="password">Пароль</label>
            <input type="password" id="password" v-model="password" required />
          </div>
          <button type="submit">Зарегистрироваться</button>
          <button type="button" @click="close">Закрыть</button>
        </form>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    data() {
      return {
        username: '',
        email: '',
        password: '',
      };
    },
    props: {
      isVisible: Boolean, // Определяем свойство для отображения модального окна
    },
    methods: {
      close() {
        this.$emit('close'); // Вызываем событие для закрытия модального окна
      },
      handleSubmit() {
        // Здесь можно добавить логику для регистрации пользователя
        alert('Регистрация успешна!');
        this.close();
      },
    },
  };
  </script>
  
  <style scoped>
  .modal-overlay {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, 0.5);
    display: flex;
    justify-content: center;
    align-items: center;
  }
  
  .modal-content {
    background: white;
    padding: 20px;
    border-radius: 8px;
    width: 300px;
  }
  
  button {
    margin-top: 10px;
    padding: 10px;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    cursor: pointer;
  }
  
  button[type="button"] {
    background-color: #f44336;
  }
  
  button:hover {
    opacity: 0.8;
  }
  </style>
  