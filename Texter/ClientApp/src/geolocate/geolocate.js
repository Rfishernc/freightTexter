
const geolocate = test => new Promise((resolve, reject) => {
  // eslint-disable-next-line no-undef

  const error = test => {
    test.setError('Geolocation is not supported in your browser.  Please use Chrome.');
    reject();
  }

  const success = position => {
    resolve(position);
  }

    navigator.geolocation.getCurrentPosition(success, () => {
      error(test);
    });
});

export default {
  geolocate,
};
