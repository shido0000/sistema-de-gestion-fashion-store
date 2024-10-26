<template >
    <q-page class="page-container" style="background: linear-gradient(146deg,#000000  0%, #c8c8c8 121.21%)">
      <div class="logo-container">
        <img alt="Quasar logo" src="~assets/logo_login.png" class="quasar-logo" style="height: auto; width: auto;">
      </div>
      <q-card class="q-pa-md animated-card card-login shadow-form" style="background: linear-gradient(146deg, #cfdcdc 0%, #abaeae 121.21%)"> <!-- Añadido shadow-form para la sombra -->
        <q-card-section >
          <div class="text-center">
            <div class="text-h6 text-dark">Iniciar sesión</div>
            <div class="text-subtitle2" style="color: #444444;">Accede a tu cuenta</div>
          </div>
        </q-card-section>
        <q-form @submit="onSubmit">
          <q-card-section>
            <q-input v-model="objeto.username" label="Usuario" outlined dense required
              class="q-mb-md input-animated" @focus="onFocus" @blur="onBlur" />
            <q-input v-model="objeto.contrasenna" type="password" label="Contraseña" outlined dense required
              class="input-animated" @focus="onFocus" @blur="onBlur" />
          </q-card-section>
          <q-card-actions align="right">
            <q-btn label="Iniciar sesión" type="submit"  unelevated style=" background: linear-gradient(146deg, #637171 0%, #8f9e9e 121.21%)"
              class="full-width animated-btn  " @mouseover="hover = true" @mouseleave="hover = false"
              :class="{ 'hover': hover }" />
          </q-card-actions>
        </q-form>
      </q-card>
    </q-page>
    <!-- DIALOGS -->
    <DialogLoad :dialogLoad="dialogLoad" />
  </template>



<script setup>
import { ref, reactive } from 'vue';
import { useRouter } from 'vue-router';
import { useQuasar } from 'quasar';
import DialogLoad from 'src/components/dialog_boxes/DialogLoad.vue'
import { logueo, obtenerRolLogueo } from 'src/assets/js/util/funciones'


const objetoInicial = {
    username: null,
    contrasenna: null,
}

// Crear una copia del objeto inicial
const objeto = reactive({ ...objetoInicial })

const dialogLoad = ref(false)
const username = ref('');
const password = ref('');
const hover = ref(false);
const $q = useQuasar();
const router = useRouter();

const onSubmit = () => {
    authenticate();
};

const authenticate = async () => {
    const url = 'Autenticacion/Login';

    try {
        const estado = await logueo(url, objeto, close, dialogLoad);
        console.log("x: ", estado);

        // Acceder al resultado
        const resultado = estado.resultado;
        console.log("Resultado: ", resultado);

        if (resultado !== null) {
            $q.notify({ type: 'positive', message: 'Autenticación exitosa' });
            // Redirigir o guardar el estado de autenticación
            // Guardar el usuario en el localStorage


           const objetoObtenido = await obtenerRolLogueo(`Usuario/ObtenerElementoPorUsuario/${objeto.username}`)

           console.log("XS: ", await obtenerRolLogueo(`Usuario/ObtenerElementoPorUsuario/${objeto.username}`))
           //console.log("ROL: ", rol)

            localStorage.setItem('usuario', JSON.stringify(objetoObtenido.rol.nombre));
            router.push('/Inicio');
        }
        else {
            $q.notify({ type: 'negative', message: 'Usuario o contraseña incorrectos' });
        }

    } catch (error) {
        console.error("Error en la autenticación: ", error);
        $q.notify({ type: 'negative', message: 'Error en la autenticación' });
    }
};


const onFocus = (event) => {
    event.target.closest('.q-input').classList.add('input-focused');
};

const onBlur = (event) => {
    event.target.closest('.q-input').classList.remove('input-focused');
};
</script>

<style scoped>
.page-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: normal;
    height: 100vh;
    /* Ajusta la altura del contenedor al 100% del viewport */
}

.logo-container {
    margin-bottom: 5vh;
    /* Espacio entre el logo y el formulario usando unidades relativas */
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

.shadow-form {
  box-shadow: 0 0 100px rgba(146, 137, 137, 0.934); /* Sombra gris en todo el borde */
}

</style>
