// VALIDACIONES EXTRAS
// #region  VALIDATE EXTRAS
const PonerPuntosSupensivosACampo = (text = "?", maxLength = 10) => {
    return text.length > maxLength ? text.slice(0, maxLength) + " ..." : text;
};
export { PonerPuntosSupensivosACampo };
