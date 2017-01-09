Imports MPIClient.DataAccess
Imports MPIClient.DataAccess.Model
Imports System.Net

Public Class MpiPatient
    Function search(ByVal patient As Model.Patient, ByVal grFingerX As AxGrFingerXLib.AxGrFingerXCtrl) As Object
        Dim jsonResult As Object = Nothing
        Dim fingerprintUtil As New FingerprintUtil(grFingerX)
        Dim params As New Hashtable()
        params.Add("p_fingerprint_r1", fingerprintUtil.getTemplateBase64(patient.Fingerprint_r1))
        params.Add("p_fingerprint_r2", fingerprintUtil.getTemplateBase64(patient.Fingerprint_r2))
        params.Add("p_fingerprint_r3", fingerprintUtil.getTemplateBase64(patient.Fingerprint_r3))
        params.Add("p_fingerprint_r4", fingerprintUtil.getTemplateBase64(patient.Fingerprint_r4))
        params.Add("p_fingerprint_r5", fingerprintUtil.getTemplateBase64(patient.Fingerprint_r5))
        params.Add("p_fingerprint_l1", fingerprintUtil.getTemplateBase64(patient.Fingerprint_l1))
        params.Add("p_fingerprint_l2", fingerprintUtil.getTemplateBase64(patient.Fingerprint_l2))
        params.Add("p_fingerprint_l3", fingerprintUtil.getTemplateBase64(patient.Fingerprint_l3))
        params.Add("p_fingerprint_l4", fingerprintUtil.getTemplateBase64(patient.Fingerprint_l4))
        params.Add("p_fingerprint_l5", fingerprintUtil.getTemplateBase64(patient.Fingerprint_l5))
        params.Add("p_pat_gender", patient.Gender.ToString())
        params.Add("v_site_code", "")

        Dim headerParams As New Hashtable()

        headerParams.Add("Timeout", ConfigManager.GetConfiguarationValue("RequestTimeOut"))
        Dim url = ConfigManager.GetConfiguarationValue("patients_index_url")
        Dim responseBody = MpiAccessTokenHttp.request(url, "GET", params, headerParams)
        Return responseBody

    End Function
    'ByVal uploadProgressChange As UploadProgressChangedEventHandler, ByVal uploadValuesCompleted As UploadValuesCompletedEventHandler, ByVal index As Integer
    Function sync(ByVal patient As PatientSyn)
        Dim url = ConfigManager.GetConfiguarationValue("patients_sync_url")
        Dim params As New Hashtable()

        params.Add("p_pat_id", patient.patientid)
        params.Add("p_fingerprint_r1", patient.fingerprint_r1)
        params.Add("p_fingerprint_r2", patient.fingerprint_r2)
        params.Add("p_fingerprint_r3", patient.fingerprint_r3)
        params.Add("p_fingerprint_r4", patient.fingerprint_r4)
        params.Add("p_fingerprint_r5", patient.fingerprint_r5)
        params.Add("p_fingerprint_l1", patient.fingerprint_l1)
        params.Add("p_fingerprint_l2", patient.fingerprint_l2)
        params.Add("p_fingerprint_l3", patient.fingerprint_l3)
        params.Add("p_fingerprint_l4", patient.fingerprint_l4)
        params.Add("p_fingerprint_l5", patient.fingerprint_l5)

        params.Add("p_pat_gender", patient.gender)
        params.Add("p_pat_age", patient.age)
        params.Add("v_site_code", patient.sitecode)
        params.Add("p_pat_dob", patient.datebirth)

        params.Add("p_date_create", patient.createdate)
        params.Add("p_updated_at", patient.updatedate)

        Dim headerParams As New Hashtable()


        Dim responseBody = MpiAccessTokenHttp.request(url, "POST", params, headerParams)
        Return responseBody

    End Function

End Class
