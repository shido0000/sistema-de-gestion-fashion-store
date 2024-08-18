<template>
    <q-dialog v-model="dialog" persistent>
        <q-layout container class="bg-black" style="height: 80px; max-width: 400px">
            <q-card class="bg-loading text-black">
                <q-card-section class="q-pb-none">
                    <div class="text-subtitle1 text-center">
                        <span>Cargando...</span>
                    </div>
                </q-card-section>
                <q-card-section>
                    <div class="row">
                        <div class="col-12">
                            <q-linear-progress color="black" indeterminate />
                        </div>
                    </div>
                </q-card-section>
            </q-card>
        </q-layout>
    </q-dialog>
</template>

<script setup>
import { computed } from 'vue'

defineOptions({
    name: 'DialogLoad'
})
const props = defineProps({
    dialogLoad: Boolean
})
const dialog = computed(() => props.dialogLoad)

</script>
