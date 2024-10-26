// VALIDACIONES EXTRAS
// #region  VALIDATE EXTRAS
const PonerPuntosSupensivosACampo = (text = "?", maxLength = 10) => {
    return text.length > maxLength ? text.slice(0, maxLength) + " ..." : text
}
const convertirValoresADecimal = (valor) =>{
    if (Number.isInteger(valor)) {
    return valor.toFixed(2)
  }
  else{
    return valor
  }
}



const getFechaVentaPasandoFechaDeBaseDatos = (fechaDada) => {

    const fecha = new Date(fechaDada)
    const dia = String(fecha.getDate()).padStart(2, '0')
    const mes = String(fecha.getMonth() + 1).padStart(2, '0') // Los meses en JavaScript son 0-indexados
    const anio = fecha.getFullYear()

    let horas = fecha.getHours();
    const minutos = String(fecha.getMinutes()).padStart(2, '0')
    const segundos = String(fecha.getSeconds()).padStart(2, '0')
    const ampm = horas >= 12 ? 'PM' : 'AM'
    horas = horas % 12
    horas = horas ? horas : 12 // La hora '0' debe ser '12'
    const horasFormateadas = String(horas).padStart(2, '0')

    const fechaFormateada = `${dia}/${mes}/${anio}`
    const horaFormateada = `${horasFormateadas}:${minutos}:${segundos} ${ampm}`

    return `${fechaFormateada} ${horaFormateada}`
}
export { PonerPuntosSupensivosACampo, convertirValoresADecimal, getFechaVentaPasandoFechaDeBaseDatos }
