
// VALIDACIONES FOMS
// #region  VALIDATE FORMS
const validateForms = Object.freeze({
    string: (value) => {
        if (value === null || value === '' || value === undefined) {
            return 'El campo es obligatorio'
        }
        return true
    },
    onlyLetter_Number: (value) => {
        // Permite letras, números y espacios en blanco entre palabras,
        // pero no permite espacios en blanco al inicio ni al final del texto.
        const patronCadena = /^\S[\w\s]*\S$|^\S$/;
        if (!patronCadena.test(value)) {
            return 'Por favor, ingresa solo letras y números. No permite espacios en blanco al inicio ni al final del texto.';
        }
        return true;
    },

    onlyLetter_Number_No_White_Spaces: (value) => {
        // Permite solo letras y números, sin espacios en blanco.
        const patronCadena = /^[a-zA-Z0-9]+$/;
        if (!patronCadena.test(value)) {
            return 'Por favor, ingresa solo letras y números, sin espacios en blanco.';
        }
        return true;
    }

})

export const { string, onlyLetter_Number, onlyLetter_Number_No_White_Spaces } = validateForms;
