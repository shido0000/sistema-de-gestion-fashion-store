<template>
  <q-page class="page-container">
    <div class="logo-container">
      <img
        alt="Quasar logo"
        src="~assets/quasar-logo-vertical.svg"
        class="quasar-logo"
      >
    </div>
    <q-card class="q-pa-md animated-card card-login">
      <q-card-section>
        <div class="text-center">
          <div class="text-h6 text-primary">Iniciar sesión</div>
          <div class="text-subtitle2 text-grey">Accede a tu cuenta</div>
        </div>
      </q-card-section>
      
      <q-form @submit="onSubmit">
        <q-card-section>
          <q-input 
            v-model="username" 
            label="Usuario" 
            outlined 
            dense 
            required 
            class="q-mb-md input-animated"
            @focus="onFocus" 
            @blur="onBlur"
          />
          <q-input 
            v-model="password" 
            type="password" 
            label="Contraseña" 
            outlined 
            dense 
            required 
            class="input-animated"
            @focus="onFocus" 
            @blur="onBlur"
          />
        </q-card-section>
        
        <q-card-actions align="right">
          <q-btn 
            label="Iniciar sesión" 
            type="submit" 
            color="primary" 
            unelevated 
            class="full-width animated-btn"
            @mouseover="hover=true" 
            @mouseleave="hover=false"
            :class="{ 'hover': hover }"
          />
        </q-card-actions>
      </q-form>
    </q-card>
  </q-page>
</template>

<script>
export default {
  data() {
    return {
      username: '',
      password: '',
      hover: false,
    }
  },
  methods: {
    onSubmit() {
      this.authenticate(this.username, this.password);
    },
    authenticate(username, password) {
      // Lógica de autenticación básica
      if (username === 'admin' && password === '1234') {
        this.$q.notify({ type: 'positive', message: 'Autenticación exitosa' });
        // Redirigir o guardar el estado de autenticación
        this.$router.push('/Inicio');
      } else {
        this.$q.notify({ type: 'negative', message: 'Usuario o contraseña incorrectos' });
      }
    },
    onFocus(event) {
      event.target.closest('.q-input').classList.add('input-focused');
    },
    onBlur(event) {
      event.target.closest('.q-input').classList.remove('input-focused');
    }
  }
}
</script>

<style scoped>
.page-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: normal;
  height: 100vh; /* Ajusta la altura del contenedor al 100% del viewport */
}

.logo-container {
  margin-bottom: 5vh; /* Espacio entre el logo y el formulario usando unidades relativas */
  margin-top: 2%;
  animation: fadeIn 1s ease-out;
}

.quasar-logo {
  width: 150px;
  height: 150px;
}

.animated-card {
  width: 350px;
  max-width: 90%;
  animation: fadeIn 1s ease-out;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
  border-radius: 15px;
}

.text-center {
  text-align: center;
}

.input-animated input {
  transition: box-shadow 0.3s, border-color 0.3s;
}

.input-focused input {
  box-shadow: 0 0 5px rgba(33, 150, 243, 0.5);
  border-color: #2196f3;
}

.animated-btn {
  transition: background-color 0.3s ease, transform 0.2s ease;
}

.animated-btn.hover {
  background-color: #1976D2;
  transform: scale(1.05);
}

@keyframes fadeIn {
  from {
    opacity: 0;
    transform: translateY(30px);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}
</style>
